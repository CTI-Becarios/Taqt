Imports System.Runtime.Serialization

<DataContract()>
Public Class ActionData
    <DataMember(Name:="@id")>
    Public Property Id As String
    <DataMember(Name:="@type")>
    Public Property Type As String
    Public Property id As Integer
    Public Property company As String
    Public Property device As String
    Public Property data As String
    Public Property occurrence As Date
    Public Property serverDateTime As Date
    Public Property type As String
    Public Property count As Integer
    Public Property batteryLevel1 As Integer
    Public Property batteryLevel2 As Integer
    Public Property rssi As Integer
    Public Property nfc As String
    Public Property event As String
    Public Property payload As String
    Public Property batterySignal As String
    Public Property batteryLevel As Integer
    Public Property badgeIdentifier As String
End Class
