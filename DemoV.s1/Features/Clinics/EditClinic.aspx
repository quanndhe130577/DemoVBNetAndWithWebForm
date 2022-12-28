<%@ Page Title="Edit Clinic" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditClinic.aspx.vb" Inherits="DemoV.s1.EditClinic" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <script>
      function HideResultInput() {
         document.getElementById("MainContent_resultSubmit").style.visibility = "hidden";
      }
   </script>
   <style>
      .tdLabel {
         text-align: left
      }

      .tdInput {
         padding-left: 10px;
         text-align: left;
      }

      .hyperLinkBack {
         float: right;
         padding-right: 10px;
      }

      tr, td {
         padding-bottom: 5px;
         padding-top: 5px;
      }
   </style>
   <h3 style="color: blue; font-weight: bold">Edit clinic information</h3>
   <input type="hidden" id="hiddenClinicId" runat="server" />
   <table style="margin-left: auto; margin-right: auto; width: 50%">
      <tr>
         <td class="tdLabel" style="width: 30%">Name :</td>
         <td class="tdInput">
            <input required style="width: 70%" type="text" id="inputName" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Address :</td>
         <td class="tdInput">
            <input required style="width: 100%" type="text" id="inputAddress" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Phone number :</td>
         <td class="tdInput">
            <input required type="tel" id="inputPhone" title="Clinic phone number" placeholder="10-11 numbers" pattern="[0-9]{10,11}" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
   </table>
   <label style="visibility: visible; color: red" id="resultSubmit" runat="server"></label>
   <br />
   <input
      runat="server"
      type="submit"
      value="Submit Form"
      onserverclick="SubmitForm_ServerClick">
   <br />
   <asp:HyperLink CssClass="hyperLinkBack" NavigateUrl="~/Features/Clinics/ClinicManagement.aspx" runat="server">Back to Clinic Management</asp:HyperLink>
</asp:Content>
