<%@ Page Title="New Clinic" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPatient.aspx.vb" Inherits="DemoV.s1.NewPatient" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
   <h3 style="color: blue; font-weight: bold">New patient information</h3>
   <table style="margin-left: auto; margin-right: auto; width: 50%">
      <tr>
         <td class="tdLabel">NRIC :</td>
         <td class="tdInput">
            <input required id="inputNRIC" runat="server" type="text" style="width: 50%" /></td>
      </tr>
      <tr>
         <td class="tdLabel">Name :</td>
         <td class="tdInput">
            <input required id="inputName" runat="server" type="text" style="width: 60%" /></td>
      </tr>
      <tr>
         <td class="tdLabel">DOB :</td>
         <td class="tdInput">
            <input required id="inputDOB" runat="server" type="date" /></td>
      </tr>
      <tr>
         <td class="tdLabel">Address :</td>
         <td class="tdInput">
            <input required id="inputAddress" runat="server" type="text" style="width: 100%" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Phone number :</td>
         <td class="tdInput">
            <input required id="inputPhone" title="Patient phone number" placeholder="10-11 numbers" pattern="[0-9]{10,11}" runat="server" />
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
            <button id="showImg" runat="server" onserverclick="showImg_ServerClick" style="display: none">Show Image</button>
            <img title="Avatar" src="#" style="display: none; padding-top: 5px" width="100" height="100" runat="server" id="pictureImg" />
         </td>
      </tr>
   </table>
   <br />
   <input
      runat="server"
      type="submit"
      value="Submit Form"
      onserverclick="SubmitForm_ServerClick">
   <br />
   <asp:HyperLink CssClass="hyperLinkBack" NavigateUrl="~/Features/Clinics/ClinicManagement.aspx" runat="server">Back to Clinic Management</asp:HyperLink>
</asp:Content>
