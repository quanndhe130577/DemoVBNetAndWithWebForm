Imports System.Data.SqlClient

Public Class NewClinic
   Inherits System.Web.UI.Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader
   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

   End Sub

   Protected Sub SubmitForm_ServerClick()
      Dim query As String = String.Empty
      query &= "INSERT INTO Clinics (ID, Name, Address, PhoneNumber)"
      query &= "VALUES (@id, @name, @address, @phoneNumber)"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", Guid.NewGuid())
               .Parameters.AddWithValue("@name", inputName.Value)
               .Parameters.AddWithValue("@address", inputAddress.Value)
               .Parameters.AddWithValue("@phoneNumber", inputPhone.Value)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
               Response.Redirect("ClinicManagement.aspx")
            Catch ex As SqlException
               Console.WriteLine(ex.Message.ToString())
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Sub
End Class