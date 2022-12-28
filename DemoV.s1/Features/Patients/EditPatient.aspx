<%@ Page Title="Edit Clinic" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPatient.aspx.vb" Inherits="DemoV.s1.EditPatient" %>


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

      .fileUploadInput {
         padding-top: 10px;
      }
   </style>
   <h3 style="color: blue; font-weight: bold">Edit patient information</h3>
   <input type="hidden" id="inputClinicId" runat="server" />
   <table style="margin-left: auto; margin-right: auto; width: 50%">
      <tr>
         <td class="tdLabel">NRIC :</td>
         <td class="tdInput">
            <input required type="text" id="inputNRIC" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Name :</td>
         <td class="tdInput">
            <input required type="text" id="inputName" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">DOB :</td>
         <td class="tdInput">
            <input required type="date" id="inputDOB" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Address :</td>
         <td class="tdInput">
            <input required type="text" id="inputAddress" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Phone number :</td>
         <td class="tdInput">
            <input required type="tel" id="inputPhone" title="Clinic phone number" placeholder="10-11 numbers" pattern="[0-9]{10,11}" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Image :</td>
         <td class="tdInput">
            <script type="text/javascript">
               function UploadFile(fileUpload) {
                  if (fileUpload.value != '') {
                     document.getElementById('MainContent_showImg').click();
                  }
               }
            </script>
            <asp:FileUpload title="Upload Avatar" ID="pictureUpload" onchange="UploadFile(this)" runat="server" accept=".png,.jpg,.jpeg,.gif" CssClass="fileUploadInput" />
            <button id="showImg" runat="server" onserverclick="showImg_ServerClick" style="display: none"></button>
            <img title="Avatar" src="#" style="padding-top: 5px" width="100" height="100" runat="server" id="pictureImg" />
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
   <asp:HyperLink CssClass="hyperLinkBack" NavigateUrl="~/Features/Patients/PatientManagement.aspx" runat="server">Back to Patient Management</asp:HyperLink>
</asp:Content>
