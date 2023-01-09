Imports System.Data.SqlClient
Imports DemoV.s1.ClinicServiceReference

Public Class ClinicManagement
   Inherits Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      If (Not (Page.IsPostBack)) Then
      End If
   End Sub

   Function GetClinics() As List(Of Clinic)
      Dim result = New List(Of Clinic)()

#Region "wcf_version"
      'Step 1: Create an instance of the WCF proxy.
      Dim client As ClinicServiceClient = New ClinicServiceClient()

      ' Step 2: Call the service operations.
      Dim clinics = client.GetClinics()

      ' Step 3: Close the client to gracefully close the connection and clean up resources.
      client.Close()

      For Each item In clinics
         Dim clinic As Clinic = New Clinic
         clinic.ID = item.ID
         clinic.Name = item.Name
         clinic.Address = item.Address
         clinic.PhoneNumber = item.PhoneNumber

         result.Add(clinic)
      Next
#End Region

#Region "normal_version"
      'Dim result = New List(Of Clinic)()
      ''Create a Connection object.
      'myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      ''Create a Command object.
      'myCmd = myConn.CreateCommand
      'myCmd.CommandText = "SELECT ID, Name, Address, PhoneNumber FROM Clinics"
      ''Open the connection.
      'myConn.Open()

      'myReader = myCmd.ExecuteReader()
      'Do While myReader.Read()
      '   Dim clinic As Clinic = New Clinic
      '   clinic.ID = myReader.GetGuid(0)
      '   clinic.Name = myReader.GetString(1)
      '   clinic.Address = myReader.GetString(2)
      '   clinic.PhoneNumber = myReader.GetString(3)

      '   result.Add(clinic)
      'Loop

      ''Close the reader and the database connection.
      'myReader.Close()
      'myConn.Close()
#End Region

      Return result
   End Function

   Protected Sub DeleteClinic(ByVal sender As Object, ByVal e As EventArgs)
#Region "normal_version"
      'Dim query As String = String.Empty
      'query &= " delete Clinics "
      'query &= " where id = @id"

      'Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      '   Using comm As New SqlCommand()
      '      With comm
      '         .Connection = conn
      '         .CommandType = CommandType.Text
      '         .CommandText = query
      '         .Parameters.AddWithValue("@id", deletedIdInput.Value)
      '      End With
      '      Try
      '         conn.Open()
      '         comm.ExecuteNonQuery()
      '      Catch ex As SqlException
      '      Finally
      '         conn.Close()
      '      End Try
      '   End Using
      'End Using
#End Region

#Region "wcf_version"
      'Step 1: Create an instance of the WCF proxy.
      Dim client As ClinicServiceClient = New ClinicServiceClient()

      ' Step 2: Call the service operations.
      client.DeleteClinic(New Guid(deletedIdInput.Value))

      ' Step 3: Close the client to gracefully close the connection and clean up resources.
      client.Close()
#End Region
   End Sub
End Class