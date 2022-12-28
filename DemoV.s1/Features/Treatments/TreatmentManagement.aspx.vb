Imports System.Data.SqlClient

Public Class TreatmentManagement
   Inherits Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      If (Not (Page.IsPostBack)) Then
         Dim selectedPatientId As Guid = Guid.Empty
         If Not (Request.QueryString("patientId") Is Nothing) Then
            selectedPatientId = New Guid(Request.QueryString("patientId"))
         End If
         hiddenPatientId.Value = selectedPatientId.ToString()

         Dim selectedClinicId As Guid = Guid.Empty
         If Not (Request.QueryString("clinicId") Is Nothing) Then
            selectedClinicId = New Guid(Request.QueryString("clinicId"))
         End If
         hiddenClinicId.Value = selectedClinicId.ToString()
         DataBindDropDownListClinic(selectedClinicId)
      End If
   End Sub
   Sub DataBindDropDownListClinic(ByVal clinicId As Guid)
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

         dropDownListClinic.Items.Insert(0, New ListItem("------ All ------", Guid.Empty.ToString()))
         dropDownListClinic.Items.FindByValue(clinicId.ToString()).Selected = True

      End Using

      'Close the reader and the database connection.
      myConn.Close()
   End Sub

   Function GetTreatments(ByVal patientId As String, ByVal clinicId As String) As List(Of TreamentDto)
      Dim result = New List(Of TreamentDto)()
      'Create a Connection object.
      myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      'Create a Command object.
      myCmd = myConn.CreateCommand
      myCmd.CommandText = " SELECT t.ID, c.Name as ClinicName, p.Name as PatientName, t.VisitDate, t.Description, t.Cost "
      myCmd.CommandText &= " FROM Clinics c, Patients p, Treatments t"
      myCmd.CommandText &= " where c.Id = t.clinicId and p.Id = t.patientId"

      If (Guid.Empty.ToString() <> patientId) Then
         myCmd.CommandText &= " and p.Id = @pid"
         myCmd.Parameters.AddWithValue("@pid", patientId)
      End If

      If (Guid.Empty.ToString() <> clinicId) Then
         myCmd.CommandText &= " and c.Id = @cid"
         myCmd.Parameters.AddWithValue("@cid", clinicId)
      End If

      myCmd.CommandText &= " order by visitdate desc"
      'Open the connection.
      myConn.Open()

      myReader = myCmd.ExecuteReader()
      Do While myReader.Read()
         Dim treatmentDto As TreamentDto = New TreamentDto
         treatmentDto.ID = myReader.GetGuid(0)
         treatmentDto.ClinicName = myReader.GetString(1)
         treatmentDto.PatientName = myReader.GetString(2)
         treatmentDto.VisitDate = myReader.GetDateTime(3)
         If Not (myReader.IsDBNull(4)) Then
            treatmentDto.Description = myReader.GetString(4)
         End If
         treatmentDto.Cost = myReader.GetDecimal(5)

         result.Add(treatmentDto)
      Loop

      'Close the reader and the database connection.
      myReader.Close()
      myConn.Close()
      Return result
   End Function

   Protected Sub DeleteTreatment(ByVal sender As Object, ByVal e As EventArgs)
      Dim query As String = String.Empty
      query &= " delete Treatments "
      query &= " where id = @id"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", deletedIdInput.Value)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
            Catch ex As SqlException
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Sub
   Protected Sub dropDownListClinic_SelectedIndexChanged(sender As Object, e As EventArgs)
      Dim clinicId = dropDownListClinic.SelectedValue
      hiddenClinicId.Value = clinicId
   End Sub
End Class