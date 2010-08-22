<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="MoleASPNETTestBench._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mole For Visual Studio - Mole Burrows Deep Into ASP.NET</title>
</head>
<body>
    <form id="form1" runat="server">
            
        <table bgcolor="#99b4d1" cellpadding="10">
        <tr>
            <td>
        <table cellpadding="10" bgcolor="WhiteSmoke">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/mole.gif" />
                </td>
                <td>
                    <table border="1" cellspacing="10">
                        <tr>
                            <td>
                                <!-- please don't laugh @ Karl's html.  I did this project in 10 minutes -->
                                <br />
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="RadioButton1" /><br /><br />
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="RadioButton2" /><br /><br />
                                <asp:RadioButton ID="RadioButton3" runat="server" Text="RadioButton3" /><br />
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridView1" CellPadding="5" runat="server"></asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Click To Molenate" />
                </td>
            </tr>
           
        </table>
            
            </td>
        
        </tr>
        
        </table>
       

    
    </form>
</body>
</html>
