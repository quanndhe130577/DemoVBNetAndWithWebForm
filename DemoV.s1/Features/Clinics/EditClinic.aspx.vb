Imports System.Data.SqlClient

Public Class EditClinic
   Inherits System.Web.UI.Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If (Not (Page.IsPostBack)) Then
         Dim ClinicId As Guid = Guid.Empty
         If Not (Request.QueryString("clinicId") Is Nothing) Then
            Dim a As String = Request.QueryString("clinicId")
            ClinicId = New Guid(Request.QueryString("clinicId"))
            hiddenClinicId.Value = ClinicId.ToString()
         End If

         Dim Query As String = "Select top 1 Name, Address, PhoneNumber from Clinics where id = @id"
         Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
            Using comm As New SqlCommand()
               With comm
                  .Connection = conn
                  .CommandType = CommandType.Text
                  .CommandText = Query
                  .Parameters.AddWithValue("@id", ClinicId)
               End With
               Try
                  conn.Open()
                  myReader = comm.ExecuteReader()
                  Do While myReader.Read()
                     inputName.Value = myReader.GetString(0)
                     inputAddress.Value = myReader.GetString(1)
                     inputPhone.Value = myReader.GetString(2)
                     Exit Do
                  Loop

               Catch ex As SqlException
                  resultSubmit.InnerText = "Clinic information cannot found !!!"
               Finally
                  conn.Close()
               End Try
            End Using
         End Using
      End If
   End Sub

   Protected Sub SubmitForm_ServerClick()
      Dim query As String = String.Empty
      query &= " Update Clinics "
      query &= " set name = @name, address = @address, phoneNumber = @phoneNumber"
      query &= " where id = @id"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", hiddenClinicId.Value)
               .Parameters.AddWithValue("@name", inputName.Value)
               .Parameters.AddWithValue("@address", inputAddress.Value)
               .Parameters.AddWithValue("@phoneNumber", inputPhone.Value)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
               resultSubmit.Visible = True
               resultSubmit.InnerText = "Clinic information updated successfully !!!"
            Catch ex As SqlException
               resultSubmit.InnerText = "Clinic information updated failed. Try again !!!"
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Sub

   Protected Sub txt_OnTextChanged()
      resultSubmit.Visible = False
   End Sub

End Class