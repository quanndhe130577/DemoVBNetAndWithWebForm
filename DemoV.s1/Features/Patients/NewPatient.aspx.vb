Imports System.Data.SqlClient
Imports DemoV.s1.PatientServiceReference

Public Class NewPatient
   Inherits System.Web.UI.Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader
   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
   End Sub

   Protected Sub SubmitForm_ServerClick()
#Region "normal_version"
      'Dim query As String = String.Empty
      'query &= " INSERT INTO Patients (ID, NRIC, Name, DateOfBirth, Address, PhoneNumber, Picture)"
      'query &= " VALUES (@id, @nric, @name, @dob, @address, @phoneNumber, @pic)"

      'Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      '   Using comm As New SqlCommand()
      '      With comm
      '         .Connection = conn
      '         .CommandType = CommandType.Text
      '         .CommandText = query
      '         .Parameters.AddWithValue("@id", Guid.NewGuid())
      '         .Parameters.AddWithValue("@nric", inputNRIC.Value)
      '         .Parameters.AddWithValue("@name", inputName.Value)
      '         .Parameters.AddWithValue("@dob", inputDOB.Value)
      '         .Parameters.AddWithValue("@address", inputAddress.Value)
      '         .Parameters.AddWithValue("@phoneNumber", inputPhone.Value)
      '         .Parameters.AddWithValue("@pic", Convert.ToBase64String(pictureUpload.FileBytes))
      '      End With
      '      Try
      '         conn.Open()
      '         comm.ExecuteNonQuery()
      '         Response.Redirect("PatientManagement.aspx")
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
         Dim client As PatientServiceClient = New PatientServiceClient()
         Dim result = client.AddNewPatient(
            inputNRIC.Value,
            inputName.Value,
            inputDOB.Value,
            inputAddress.Value,
            inputPhone.Value,
            Convert.ToBase64String(pictureUpload.FileBytes))
         client.Close()

         If result Then
            Response.Redirect("PatientManagement.aspx")
         End If
      Catch ex As Exception
         Console.WriteLine(ex.Message.ToString())
      End Try
#End Region
   End Sub

   Protected Sub showImg_ServerClick(sender As Object, e As EventArgs)
      pictureImg.Src = "data:image/png;base64," + Convert.ToBase64String(pictureUpload.FileBytes)
      pictureImg.Style.Add("display", "block")
   End Sub
End Class