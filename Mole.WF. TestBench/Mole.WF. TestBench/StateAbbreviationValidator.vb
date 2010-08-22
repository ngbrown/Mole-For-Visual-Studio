Public Class StateAbbreviationValidator

    Private _objStates As Dictionary(Of String, String)
    Private Shared _objInstance As StateAbbreviationValidator

    Private Sub New()
        _objStates = New Dictionary(Of String, String)
        _objStates.Add("AL", "ALABAMA")
        _objStates.Add("AK", "ALASKA")
        _objStates.Add("AS", "AMERICAN SAMOA")
        _objStates.Add("AZ", "ARIZONA")
        _objStates.Add("AR", "ARKANSAS")
        _objStates.Add("CA", "CALIFORNIA")
        _objStates.Add("CO", "COLORADO")
        _objStates.Add("CT", "CONNECTICUT")
        _objStates.Add("DE", "DELAWARE")
        _objStates.Add("DC", "DISTRICT OF COLUMBIA")
        _objStates.Add("FM", "FEDERATED STATES OF MICRONESIA")
        _objStates.Add("FL", "FLORIDA")
        _objStates.Add("GA", "GEORGIA")
        _objStates.Add("GU", "GUAM")
        _objStates.Add("HI", "HAWAII")
        _objStates.Add("ID", "IDAHO")
        _objStates.Add("IL", "ILLINOIS")
        _objStates.Add("IN", "INDIANA")
        _objStates.Add("IA", "IOWA")
        _objStates.Add("KS", "KANSAS")
        _objStates.Add("KY", "KENTUCKY")
        _objStates.Add("LA", "LOUISIANA")
        _objStates.Add("ME", "MAINE")
        _objStates.Add("MH", "MARSHALL ISLANDS")
        _objStates.Add("MD", "MARYLAND")
        _objStates.Add("MA", "MASSACHUSETTS")
        _objStates.Add("MI", "MICHIGAN")
        _objStates.Add("MN", "MINNESOTA")
        _objStates.Add("MS", "MISSISSIPPI")
        _objStates.Add("MO", "MISSOURI")
        _objStates.Add("MT", "MONTANA")
        _objStates.Add("NE", "NEBRASKA")
        _objStates.Add("NV", "NEVADA")
        _objStates.Add("NH", "NEW HAMPSHIRE")
        _objStates.Add("NJ", "NEW JERSEY")
        _objStates.Add("NM", "NEW MEXICO")
        _objStates.Add("NY", "NEW YORK")
        _objStates.Add("NC", "NORTH CAROLINA")
        _objStates.Add("ND", "NORTH DAKOTA")
        _objStates.Add("MP", "NORTHERN MARIANA ISLANDS")
        _objStates.Add("OH", "OHIO")
        _objStates.Add("OK", "OKLAHOMA")
        _objStates.Add("OR", "OREGON")
        _objStates.Add("PW", "PALAU")
        _objStates.Add("PA", "PENNSYLVANIA")
        _objStates.Add("PR", "PUERTO RICO")
        _objStates.Add("RI", "RHODE ISLAND")
        _objStates.Add("SC", "SOUTH CAROLINA")
        _objStates.Add("SD", "SOUTH DAKOTA")
        _objStates.Add("TN", "TENNESSEE")
        _objStates.Add("TX", "TEXAS")
        _objStates.Add("UT", "UTAH")
        _objStates.Add("VT", "VERMONT")
        _objStates.Add("VI", "VIRGIN ISLANDS")
        _objStates.Add("VA", "VIRGINIA")
        _objStates.Add("WA", "WASHINGTON")
        _objStates.Add("WV", "WEST VIRGINIA")
        _objStates.Add("WI", "WISCONSIN")
        _objStates.Add("WY", "WYOMING")

        'leave it up to the government to screw this up!!!
        'Using AE 4 times.  Who's incharge up there!  Your tax dollars hard at work.
        '
        '     _objStates.Add("AE", "Armed Forces Africa")
        _objStates.Add("AA", "Armed Forces Americas")
        '        _objStates.Add("AE", "Armed Forces Canada")
        _objStates.Add("AE", "Armed Forces Europe")
        '      _objStates.Add("AE", "Armed Forces Middle East")
        _objStates.Add("AP", "Armed Forces Pacific")

    End Sub

    Public Shared Function GetInstance() As StateAbbreviationValidator
        If _objInstance Is Nothing Then
            _objInstance = New StateAbbreviationValidator
        End If
        Return _objInstance
    End Function

    Public Function IsValid(ByVal strStateAbbreviation As String) As Boolean
        Return _objStates.ContainsKey(strStateAbbreviation.ToUpper)
    End Function

    Public Function GetStateName(ByVal strStateAbbreviation As String) As String
        If IsValid(strStateAbbreviation) Then
            Return _objStates(strStateAbbreviation.ToUpper)
        Else
            Return String.Format("State abbreviation: {0}, is not valid", strStateAbbreviation)
        End If
    End Function
End Class
