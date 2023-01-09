Imports System.Data.SqlClient
Imports DemoV.s1.ClinicServiceReference

Public Class NewClinic
   Inherits System.Web.UI.Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader
   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

   End Sub

   Protected Sub SubmitForm_ServerClick()
#Region "normal_version"
      'Dim query As String = String.Empty
      'query &= "INSERT INTO Clinics (ID, Name, Address, PhoneNumber)"
      'query &= "VALUES (@id, @name, @address, @phoneNumber)"

      'Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      '   Using comm As New SqlCommand()
      '      With comm
      '         .Connection = conn
      '         .CommandType = CommandType.Text
      '         .CommandText = query
      '         .Parameters.AddWithValue("@id", Guid.NewGuid())
      '         .Parameters.AddWithValue("@name", inputName.Value)
      '         .Parameters.AddWithValue("@address", inputAddress.Value)
      '         .Parameters.AddWithValue("@phoneNumber", inputPhone.Value)
      '      End With
      '      Try
      '         conn.Open()
      '         comm.ExecuteNonQuery()
      '         Response.Redirect("ClinicManagement.aspx")
      '      Catch ex As SqlException
      '         Console.WriteLine(ex.Message.ToString())
      '      Finally
      '         conn.Close()
      '      End Try
      '   End Using
      'End Using
#End Region
#Region "wcf_version"
      Try
         Dim client As ClinicServiceClient = New ClinicServiceClient()
         Dim result = client.AddNewClinic(inputName.Value, inputAddress.Value, inputPhone.Value)
         client.Close()

         If result Then
            Response.Redirect("ClinicManagement.aspx")
         End If
      Catch ex As Exception
         Console.WriteLine(ex.Message.ToString())
      End Try
#End Region
   End Sub
End Class