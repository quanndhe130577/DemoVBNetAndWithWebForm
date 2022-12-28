Imports System.Data.SqlClient

Public Class PatientManagement
   Inherits Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      If (Not (Page.IsPostBack)) Then
         'Dim clinics = GetClinics()
         Dim selectedClinicId As Guid = Guid.Empty
         If Not (Request.QueryString("clinicId") Is Nothing) Then
            selectedClinicId = New Guid(Request.QueryString("clinicId"))
         End If

         hiddenClinicId.Value = selectedClinicId.ToString()
         DataBindDropDownListClinic(selectedClinicId)
         'dropdownListClinic.DataSource = clinics
         'dropdownListClinic.DataValueField = "id"
         'dropdownListClinic.DataTextField = "Name"
         'dropdownListClinic.DataBind()
         'dropdownListClinic.Items.FindByValue(selectedClinicId.ToString()).Selected = True
      End If
   End Sub

   Function GetClinics() As List(Of Clinic)
      Dim result = New List(Of Clinic)()
      'Create a Connection object.
      myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      'Create a Command object.
      myCmd = myConn.CreateCommand
      myCmd.CommandText = "SELECT ID, Name, Address, PhoneNumber FROM Clinics"
      'Open the connection.
      myConn.Open()

      myReader = myCmd.ExecuteReader()
      Do While myReader.Read()
         Dim clinic As Clinic = New Clinic
         clinic.ID = myReader.GetGuid(0)
         clinic.Name = myReader.GetString(1)
         clinic.Address = myReader.GetString(2)
         clinic.PhoneNumber = myReader.GetString(3)

         result.Add(clinic)
      Loop

      'Close the reader and the database connection.
      myReader.Close()
      myConn.Close()
      Return result
   End Function

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

   Function GetPatients(ByVal clinicId As String) As List(Of Patient)
      Dim result = New List(Of Patient)()
      'Create a Connection object.
      myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      'Create a Command object.
      myCmd = myConn.CreateCommand
      myCmd.CommandText = "SELECT p.ID, p.NRIC, p.Name, p.DateOfBirth, p.Address, p.PhoneNumber "

      If (Guid.Empty.ToString() = clinicId) Then
         myCmd.CommandText &= " FROM Patients p"
      Else
         myCmd.CommandText &= " FROM Patients p, Clinics c, Treatments t"
         myCmd.CommandText &= " where p.id = t.patientId and c.id = t.clinicId and c.Id = @clinicId"
         myCmd.Parameters.AddWithValue("@clinicId", clinicId)
      End If

      'Open the connection.
      myConn.Open()

      myReader = myCmd.ExecuteReader()
      Do While myReader.Read()
         Dim patient As Patient = New Patient
         patient.ID = myReader.GetGuid(0)
         patient.NRIC = myReader.GetString(1)
         patient.Name = myReader.GetString(2)
         patient.DateOfBirth = myReader.GetDateTime(3)
         patient.Address = myReader.GetString(4)
         patient.PhoneNumber = myReader.GetString(5)

         result.Add(patient)
      Loop

      'Close the reader and the database connection.
      myReader.Close()
      myConn.Close()
      Return result
   End Function

   Protected Sub DeletePatient(ByVal sender As Object, ByVal e As EventArgs)
      Dim query As String = String.Empty
      query &= " delete Patients "
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