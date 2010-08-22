Imports System.Drawing
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Runtime.InteropServices

Public Class VisualSnapshot

#Region " Declarations "

    Private Const WM_PRINT As Integer = &H317
    Private Const WM_PRINTCLIENT As Integer = &H318
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As PRF_Flags) As IntPtr

    End Function

    <Flags()> _
    Private Enum PRF_Flags As Integer
        PRF_CHECKVISIBLE = &H1
        PRF_NONCLIENT = &H2
        PRF_CLIENT = &H4
        PRF_ERASEBKGND = &H8
        PRF_CHILDREN = &H10
        PRF_OWNED = &H20
    End Enum

#End Region

#Region " Methods "

    Private Shared Function BitmapSourceToGDIImage(ByVal bitmapSource As BitmapSource) As System.Drawing.Bitmap

        Dim intWidth As Integer = bitmapSource.PixelWidth
        Dim intHeight As Integer = bitmapSource.PixelHeight
        Dim intStride As Integer = CInt(intWidth * ((bitmapSource.Format.BitsPerPixel + 7) / 8))

        'this code ensures that the stride is a multiple of 4
        'learned a lot about stride here: http://www.bobpowell.net/lockingbits.htm
        Dim intStrideFixer As Integer = intStride Mod 4

        'this ensures we are on a four pixel boundary
        If intStrideFixer <> 0 Then
            intStride += 4 - intStrideFixer
        End If

        Dim bits As Byte() = New Byte(intHeight * intStride - 1) {}
        bitmapSource.CopyPixels(bits, intStride, 0)

        Dim bitmap As System.Drawing.Bitmap = Nothing

        'the following optimization was suggested by Andrew Smith
        'Mole used to have to call a C# function becuase unsafe code had to be called.
        'With this code, Mole no longer requires a call to unsafe code.
        'Oh, VB.NET pointers in ACTION!
        'Thanks DrewS :-))
        Dim handle As GCHandle = GCHandle.Alloc(bits, GCHandleType.Pinned)

        Try

            Dim ptr As IntPtr = handle.AddrOfPinnedObject()
            bitmap = New System.Drawing.Bitmap(intWidth, intHeight, intStride, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ptr)

        Catch ex As Exception

            'this is our insurance policy
            ' if we get here, function will return Nothing which is OK
        Finally
            handle.Free()
        End Try

        Return bitmap

    End Function

    Private Shared Function CaptureVisual(ByVal target As Visual, ByVal intHeight As Integer, ByVal intWidth As Integer) As BitmapSource

        'learned a lot from this article
        'http://www.wiredprairie.us/downloads/GhostCursor.cs.txt
        Dim objRenderBitmap As New RenderTargetBitmap(intWidth, intHeight, 96, 96, PixelFormats.Pbgra32)
        Dim dv As New DrawingVisual()
        Using ctx As DrawingContext = dv.RenderOpen()
            ctx.DrawRectangle(New VisualBrush(target), Nothing, New Rect(New System.Windows.Point(), VisualTreeHelper.GetDescendantBounds(target).Size))
        End Using
        objRenderBitmap.Render(dv)
        Return objRenderBitmap

    End Function

    ''' <summary>
    ''' For target object, returns a bitmap image.
    ''' </summary>
    ''' <remarks>
    '''   This code looks a little funky because under very limited circumstances during the edit of an object, the image 
    '''   may not be returned on the first pass.  So a second pass is attempted.  Failing that, return the default image.
    ''' </remarks>
    Public Shared Function TakeSnapshot(ByVal target As Object) As System.Drawing.Bitmap

        Try
            Return TakeSnapshotImpl(target)
        Catch ex As Exception
            Try
                Return TakeSnapshotImpl(target)
            Catch
                Return New System.Drawing.Bitmap(My.Resources.MoleVisualUnavailable)
            End Try
        End Try
    End Function


    Private Shared Function TakeSnapshotImpl(ByVal target As Object) As System.Drawing.Bitmap

        Dim objBitmap As System.Drawing.Bitmap = Nothing


        If TypeOf target Is BitmapSource Then
            objBitmap = BitmapSourceToGDIImage(DirectCast(target, BitmapSource))

        ElseIf TypeOf target Is Forms.Form Then

            'This code was authored by Andrew Smith
            Dim ctrl As Forms.Control = DirectCast(target, Forms.Control)

            If ctrl.Width > 0 AndAlso ctrl.Height > 0 Then
                objBitmap = New System.Drawing.Bitmap(ctrl.ClientSize.Width, ctrl.ClientSize.Height)
                Using g As Graphics = Graphics.FromImage(objBitmap)

                    Dim hdc As IntPtr = g.GetHdc()
                    'using the DrawToBitmap method causes the control to paint
                    'its non-client area as well. this should be ok but doing this
                    'for a form is causing a problem when you try to continue
                    'running the application after viewing the visual in the 
                    'visualizer. to get around this, we'll ask the form to 
                    'paint within including its non-client area. i was going to send
                    'a WM_PRINT and have it include its children as well but .net
                    'seems to have a bug and doing so causes it to render the children
                    'offset down by the non-client area anyway. instead, we'll just have it
                    'render itself and ask the children to draw separately below
                    SendMessage(New HandleRef(ctrl, ctrl.Handle), WM_PRINT, hdc, PRF_Flags.PRF_CHECKVISIBLE Or PRF_Flags.PRF_CLIENT Or PRF_Flags.PRF_ERASEBKGND)
                    g.ReleaseHdc(hdc)
                End Using

                For Each child As Forms.Control In ctrl.Controls

                    If child.Visible Then
                        child.DrawToBitmap(objBitmap, New Rectangle(child.Location, child.Size))
                    End If

                Next

            End If

        ElseIf TypeOf target Is Forms.Control Then

            'This code was authored by Andrew Smith
            Dim ctrl As Forms.Control = DirectCast(target, Forms.Control)

            If ctrl.Width > 0 AndAlso ctrl.Height > 0 Then
                objBitmap = New System.Drawing.Bitmap(ctrl.Width, ctrl.Height)
                ctrl.DrawToBitmap(objBitmap, New Rectangle(0, 0, ctrl.Width, ctrl.Height))
            End If

        ElseIf TypeOf target Is FrameworkElement Then

            Dim fe As FrameworkElement = DirectCast(target, FrameworkElement)
            'Property changes could cause the cached look to be invalid.
            '
            fe.UpdateLayout()

            'I know it looks strange, but a visual can have a height of 100 and a width of .4
            If 0 < fe.ActualHeight AndAlso 0 < fe.ActualWidth AndAlso TypeOf target Is Visual Then

                'so, if the visual has a width of .4, casting to an integer will result in size of 0
                'meaning, we won't see anything, so lets fudge so we can at least see one pixel
                'Math.Ceiling can't blow up here because we have checked the values above to ensure that they are numbers.
                Dim intHeight As Integer = CType(Math.Ceiling(fe.ActualHeight), Integer)
                Dim intWidth As Integer = CType(Math.Ceiling(fe.ActualWidth), Integer)

                'this is one last and final test to ensure that we don't throw an exception when rendering the image
                If intHeight > 0 AndAlso intWidth > 0 Then
                    objBitmap = BitmapSourceToGDIImage(CaptureVisual(DirectCast(target, Visual), intHeight, intWidth))
                End If

            End If

        End If

        If objBitmap Is Nothing Then
            'if the above code did not create the image, then return the unavailable image from project resources
            'this typically occurs when the target has either an ActualHeight of 0 or an ActualWidth of 0
            objBitmap = New System.Drawing.Bitmap(My.Resources.MoleVisualUnavailable)
            Return objBitmap

        Else
            'this is required to prevent memory corruption
            Using objBitmap
                Return New System.Drawing.Bitmap(objBitmap)
            End Using
        End If

    End Function

#End Region

End Class
