Imports System.Data.SqlClient
Imports DemoV.s1.PatientServiceReference

Public Class EditPatient
   Inherits System.Web.UI.Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If (Not (Page.IsPostBack)) Then
         Dim patientId As Guid = Guid.Empty
         If Not (Request.QueryString("patientId") Is Nothing) Then
            patientId = New Guid(Request.QueryString("patientId"))
            inputClinicId.Value = patientId.ToString()
         End If

#Region "normal_version"
         'Dim Query As String = "Select top 1 NRIC, Name ,DateOfBirth, Address, PhoneNumber, Picture from Patients where id = @id"
         'Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         '   Using comm As New SqlCommand()
         '      With comm
         '         .Connection = conn
         '         .CommandType = CommandType.Text
         '         .CommandText = Query
         '         .Parameters.AddWithValue("@id", patientId)
         '      End With
         '      Try
         '         conn.Open()
         '         myReader = comm.ExecuteReader()
         '         Do While myReader.Read()
         '            inputNRIC.Value = myReader.GetString(0)
         '            inputName.Value = myReader.GetString(1)
         '            inputDOB.Value = myReader.GetDateTime(2).ToString("yyyy-MM-dd")
         '            inputAddress.Value = myReader.GetString(3)
         '            inputPhone.Value = myReader.GetString(4)
         '            If myReader.IsDBNull(5) Then
         '               pictureImg.Style.Add("display", "none")
         '            Else
         '               pictureImg.Src = "data:image/png;base64," + myReader.GetString(5)
         '            End If
         '            Exit Do
         '         Loop

         '      Catch ex As SqlException
         '         resultSubmit.InnerText = "Patient information cannot found !!!"
         '      Finally
         '         conn.Close()
         '      End Try
         '   End Using
         'End Using
#End Region
#Region "wcf_version"
         Dim client As PatientServiceClient = New PatientServiceClient()
         Dim patient = client.GetPatientById(patientId)
         client.Close()
         If patient IsNot Nothing Then
            inputNRIC.Value = patient.NRIC
            inputName.Value = patient.Name
            inputDOB.Value = patient.DateOfBirth.ToString("yyyy-MM-dd")
            inputAddress.Value = patient.Address
            inputPhone.Value = patient.PhoneNumber
            If patient.Picture IsNot Nothing Then
               pictureImg.Style.Add("display", "none")
            Else
               pictureImg.Src = "data:image/png;base64," + patient.Picture
            End If
         Else
            resultSubmit.InnerText = "Patient information cannot found !!!"
         End If
#End Region
      End If
   End Sub

   Protected Sub SubmitForm_ServerClick()
#Region "normal_version"
      'Dim query As String = String.Empty
      'query &= " Update Patients "
      'query &= " set NRIC = @nric, name = @name, dateOfBirth = @dob, address = @address, phoneNumber = @phoneNumber"
      'If pictureUpload.HasFile Then
      '   query &= " , picture = @pic"
      'End If

      'query &= " where id = @id"

      'Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      '   Using comm As New SqlCommand()
      '      With comm
      '         .Connection = conn
      '         .CommandType = CommandType.Text
      '         .CommandText = query
      '         .Parameters.AddWithValue("@id", inputClinicId.Value)
      '         .Parameters.AddWithValue("@nric", inputNRIC.Value)
      '         .Parameters.AddWithValue("@name", inputName.Value)
      '         .Parameters.AddWithValue("@dob", inputDOB.Value)
      '         .Parameters.AddWithValue("@address", inputAddress.Value)
      '         .Parameters.AddWithValue("@phoneNumber", inputPhone.Value)

      '         If pictureUpload.HasFile Then
      '            comm.Parameters.AddWithValue("@pic", Convert.ToBase64String(pictureUpload.FileBytes))
      '         End If

      '      End With
      '      Try
      '         conn.Open()
      '         comm.ExecuteNonQuery()
      '         resultSubmit.Visible = True
      '         resultSubmit.InnerText = "Patient information updated successfully !!!"
      '      Catch ex As SqlException
      '         resultSubmit.InnerText = "Patient information updated failed. Try again !!!"
      '      Finally
      '         conn.Close()
      '      End Try
      '   End Using
      'End Using
#End Region
#Region "wcf_version"
      Try
         Dim client As PatientServiceClient = New PatientServiceClient()
         Dim result = client.UpdatePatientById(
            New Guid(inputClinicId.Value),
            inputNRIC.Value,
            inputName.Value,
            inputDOB.Value,
            inputAddress.Value,
            inputPhone.Value,
            Convert.ToBase64String(pictureUpload.FileBytes))
         client.Close()

         If result Then
            resultSubmit.Visible = True
            resultSubmit.InnerText = "Patient information updated successfully !!!"
         Else
            resultSubmit.InnerText = "Patient information updated failed. Try again !!!"
         End If
      Catch ex As Exception
         resultSubmit.InnerText = "Patient information updated failed. Try again !!!"
      End Try
#End Region
   End Sub


   Protected Sub txt_OnTextChanged()
      resultSubmit.Visible = False
   End Sub
   Protected Sub showImg_ServerClick(sender As Object, e As EventArgs)
      pictureImg.Src = "data:image/png;base64," + Convert.ToBase64String(pictureUpload.FileBytes)
      pictureImg.Style.Add("display", "block")
   End Sub
End Class