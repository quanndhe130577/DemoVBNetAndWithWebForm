<%@ Page Title="Treatment Management" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TreatmentManagement.aspx.vb" Inherits="DemoV.s1.TreatmentManagement" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <h2 style="color: blue; font-weight: bold"><%: Title %></h2>
   <style>
      .hyperlink {
         float: right;
         margin-right: 10px;
         margin-bottom: 10px;
         border: 1px solid blue;
         padding: 2px 10px;
         background-color: blue;
         color: white;
         font-weight: bold;
      }

         .hyperlink:hover {
            background-color: white;
            color: blue;
         }

      .dropDownClinic {
         float: left;
         margin-left: 10px;
         height: 30px;
         width: 30%;
      }
   </style>
   <input type="hidden" id="hiddenPatientId" runat="server" />
   <input type="hidden" id="hiddenClinicId" runat="server" />
   <div style="width: 100%">
      <asp:HyperLink NavigateUrl="~/Features/Treatments/NewTreatment.aspx" runat="server" Font-Underline="false" BorderStyle="Double" CssClass="hyperlink">New Treatment</asp:HyperLink>
      <%If hiddenPatientId.Value = Guid.Empty.ToString%>
      <p style="float: left; font-weight: bold; font-size: 20px; padding-top: 5px;">Clinic: </p>
      <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="dropDownListClinic_SelectedIndexChanged" CssClass="dropDownClinic" runat="server" ID="dropDownListClinic"></asp:DropDownList>
      <%End If%>
   </div>
   <br />
   <%Dim listTreatment = GetTreatments(hiddenPatientId.Value, hiddenClinicId.Value)
      If listTreatment.Count > 0 Then%>
   <style>
      table, tr, th, td {
         padding: 10px
      }

      th, .actionColumn {
         text-align: center
      }
   </style>
   <table border="1" style="margin-left: auto; margin-right: auto; width: 100%">
      <tr>
         <th>Clinic</th>
         <th>Patient</th>
         <th>Visit date</th>
         <th>Description</th>
         <th>Cost</th>
         <th>Actions</th>
      </tr>
      <%For Each item In listTreatment%>
      <tr>
         <td><%=item.ClinicName %></td>
         <td><%=item.PatientName %></td>
         <td><%=item.VisitDate.ToString("dd-MMM-yyyy") %></td>
         <td><%=item.Description %></td>
         <td><%=item.Cost %></td>
         <td class="actionColumn">
            <a href="EditTreatment.aspx?clinicId=<%=item.id%>">Edit</a>
            |
            <a class="deleteButton" data-id="<%=item.ID%>" href="javascript:void(0)">Delete</a>
         </td>
      </tr>
      <% Next %>
   </table>
   <%Else%>
   <h2>No treatment</h2>
   <% End If %>

   <input type="hidden" id="deletedIdInput" runat="server" />
   <script>
      // Get the button that opens the modal
      var btn = document.getElementsByClassName("deleteButton");

      // When the user clicks on the button, open the modal
      for (var i = 0; i < btn.length; i++) {
         btn[i].addEventListener('click', DisplayDeleteModal, false);
      }

      function DisplayDeleteModal() {
         document.getElementById("MainContent_deletedIdInput").value = $(this).data("id")
         document.getElementById("deleteConfirmModal").style.display = "block";
      }

      // When the user clicks anywhere outside of the modal, close it
      window.onclick = function (event) {
         var modal = document.getElementById("deleteConfirmModal");
         if (event.target == modal) {
            modal.style.display = "none";
         }
      }
   </script>
   <style>
      /* The Modal (background) */
      .modal {
         display: none; /* Hidden by default */
         position: fixed; /* Stay in place */
         z-index: 1; /* Sit on top */
         left: 0;
         top: 0;
         width: 100%; /* 50% width */
         height: 100%; /* Full height */
         overflow: auto; /* Enable scroll if needed */
         background-color: rgb(0,0,0); /* Fallback color */
         background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
      }

      /* Modal Content/Box */
      .modal-content {
         background-color: #fefefe;
         margin: 15% auto; /* 15% from the top and centered */
         padding: 20px;
         border: 1px solid #888;
         width: 20%; /* Could be more or less, depending on screen size */
      }
   </style>
   <!-- The Modal -->
   <div id="deleteConfirmModal" class="modal">
      <!-- Modal content -->
      <div class="modal-content" style="text-align: center">
         <p>Are you trying to delete clinic?</p>
         <button type="button" onserverclick="DeleteTreatment" id="yesButton" runat="server">YES</button>
         <button type="button">NO</button>
      </div>
   </div>
</asp:Content>
