﻿<%@ Page Title="Clinic Management" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClinicManagement.aspx.vb" Inherits="DemoV.s1.ClinicManagement" %>

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
   </style>
   <asp:HyperLink NavigateUrl="~/Features/Clinics/NewClinic.aspx" runat="server" Font-Underline="false" BorderStyle="Double" CssClass="hyperlink">New Clinic</asp:HyperLink>

   <br />
   <%Dim listClinic = GetClinics()
      If listClinic.Count > 0 Then%>
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
         <th style="width: 30%">Name</th>
         <th style="width: 30%">Address</th>
         <th style="width: 20%">Phone</th>
         <th style="">Patients</th>
         <th style="">Treatments</th>
         <th style="width: 20%">Actions</th>
      </tr>
      <%For Each item In listClinic%>
      <tr>
         <td><%=item.Name %></td>
         <td><%=item.Address %></td>
         <td><%=item.PhoneNumber %></td>
         <td>
            <a href="../Patients/PatientManagement.aspx?clinicId=<%=item.id%>">Patients</a>
         </td>
         <td>
            <a href="../Treatments/TreatmentManagement.aspx?clinicId=<%=item.id%>">Treatments</a>
         </td>
         <td class="actionColumn">
            <a href="EditClinic.aspx?clinicId=<%=item.id%>">Edit</a>
            |
            <a class="deleteButton" data-id="<%=item.ID%>" href="javascript:void(0)">Delete</a>
         </td>
      </tr>
      <% Next %>
   </table>
   <%Else%>
   <h2>No clinics</h2>
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
         <button type="button" onserverclick="DeleteClinic" id="yesButton" runat="server">YES</button>
         <button type="button">NO</button>
      </div>
   </div>
</asp:Content>
