Imports System.Data.SqlClient

Public Class EditTreatment
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
            hiddenTreatmentId.Value = ClinicId.ToString()
         End If

         BindingClinics()
         BindingPatients()

         Dim Query As String = "Select top 1 Id, ClinicId, PatientId, VisitDate, Description, Cost from Treatments where id = @id"
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
                     dropDownListClinic.Items.FindByValue(myReader.GetGuid(1).ToString()).Selected = True
                     dropDownPatient.Items.FindByValue(myReader.GetGuid(2).ToString()).Selected = True
                     inputDate.Value = myReader.GetDateTime(3).ToString("yyyy-MM-dd")
                     If Not (myReader.IsDBNull(4)) Then
                        inputDes.Value = myReader.GetString(4)
                     End If
                     inputCost.Value = myReader.GetDecimal(5)
                     Exit Do
                  Loop

               Catch ex As SqlException
                  resultSubmit.InnerText = "Treatment information cannot found !!!"
               Finally
                  conn.Close()
               End Try
            End Using
         End Using
      End If
   End Sub

   Sub BindingClinics()
      Dim result = New List(Of Clinic)()
      'Create a Connection object.
      myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      'Create a Command object.
      myCmd = myConn.CreateCommand
      myCmd.CommandText = "SELECT ID, Name FROM Clinics"
      'Open the connection.
      myConn.Open()

      Using sda As New SqlDataAdapter(myCmd)
         Dim ds As New DataSet()
         sda.Fill(ds)
         dropDownListClinic.DataSource = ds.Tables(0)
         dropDownListClinic.DataValueField = "ID"
         dropDownListClinic.DataTextField = "Name"
         dropDownListClinic.DataBind()
      End Using

      myConn.Close()
   End Sub

   Sub BindingPatients()
      Dim result = New List(Of Patient)()
      'Create a Connection object.
      myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      'Create a Command object.
      myCmd = myConn.CreateCommand
      myCmd.CommandText = "SELECT ID, Name FROM Patients"
      'Open the connection.
      myConn.Open()

      Using sda As New SqlDataAdapter(myCmd)
         Dim ds As New DataSet()
         sda.Fill(ds)
         dropDownPatient.DataSource = ds.Tables(0)
         dropDownPatient.DataValueField = "ID"
         dropDownPatient.DataTextField = "Name"
         dropDownPatient.DataBind()
      End Using

      myConn.Close()
   End Sub
   Protected Sub SubmitForm_ServerClick()
      Dim query As String = String.Empty
      query &= " Update Treatments "
      query &= " set clinicId = @cid, patientId = @pid, visitdate = @date, description = @des, cost = @cost"
      query &= " where id = @id"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", hiddenTreatmentId.Value)
               .Parameters.AddWithValue("@cid", dropDownListClinic.SelectedValue)
               .Parameters.AddWithValue("@pid", dropDownPatient.SelectedValue)
               .Parameters.AddWithValue("@date", inputDate.Value)
               .Parameters.AddWithValue("@des", inputDes.Value)
               .Parameters.AddWithValue("@cost", inputCost.Value)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
               resultSubmit.Visible = True
               resultSubmit.InnerText = "Treatment information updated successfully !!!"
            Catch ex As SqlException
               resultSubmit.InnerText = "Treatment information updated failed. Try again !!!"
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