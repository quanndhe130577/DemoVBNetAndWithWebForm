Imports System.Data.SqlClient

Public Class NewTreatment
   Inherits System.Web.UI.Page
   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader
   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If (Not (Page.IsPostBack)) Then
         BindingClinics()
         BindingPatients()
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
      query &= " INSERT INTO Treatments (ID, ClinicId, PatientId, VisitDate, Description, Cost)"
      query &= " VALUES (@id, @clinicid, @patientid, @date, @des, @cost)"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", Guid.NewGuid())
               .Parameters.AddWithValue("@clinicid", dropDownListClinic.SelectedValue)
               .Parameters.AddWithValue("@patientid", dropDownPatient.SelectedValue)
               .Parameters.AddWithValue("@date", inputDate.Value)
               .Parameters.AddWithValue("@des", inputDes.Value)
               .Parameters.AddWithValue("@cost", inputCost.Value)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
               Response.Redirect("TreatmentManagement.aspx")
            Catch ex As SqlException
               Console.WriteLine(ex.Message.ToString())
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Sub
End Class