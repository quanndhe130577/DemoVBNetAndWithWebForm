Public Class Reports
   Inherits System.Web.UI.Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If (Not (Page.IsPostBack)) Then
         SqlDataSource1.SelectCommand = "SELECT p.Name as PatientName, c.Name as ClinicName, p.PhoneNumber as PatientPhone, c.PhoneNumber as ClinicPhone, c.Address as ClinicAddress, *"
         SqlDataSource1.SelectCommand &= " FROM [Treatments] t, [Clinics] c, [Patients] p"
         SqlDataSource1.SelectCommand &= " Where t.PatientId = p.Id and t.ClinicId = c.Id"
      End If
   End Sub

   Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

   End Sub
End Class