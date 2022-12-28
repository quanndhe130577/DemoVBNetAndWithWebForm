<%@ Page Title="New Clinic" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewClinic.aspx.vb" Inherits="DemoV.s1.NewClinic" %>

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
   </style>
   <br />
   <h3 style="color: blue; font-weight: bold">New clinic information</h3>
   <table style="margin-left: auto; margin-right: auto; width: 50%">
      <tr>
         <td class="tdLabel" style="width: 30%">Name :</td>
         <td class="tdInput">
            <input required id="inputName" runat="server" style="width: 70%" /></td>
      </tr>
      <tr>
         <td class="tdLabel">Address :</td>
         <td class="tdInput">
            <input required id="inputAddress" runat="server" style="width: 100%" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Phone number :</td>
         <td class="tdInput">
            <input required id="inputPhone" title="Clinic phone number" placeholder="10-11 numbers" pattern="[0-9]{10,11}" runat="server" style="width: 50%" />
         </td>
      </tr>
   </table>
   <br />
   <input
      runat="server"
      type="submit"
      value="Submit Form"
      onserverclick="SubmitForm_ServerClick" />
   <br />
   <asp:HyperLink NavigateUrl="~/Features/Clinics/ClinicManagement.aspx" runat="server" CssClass="hyperLinkBack">Back to Clinic Management</asp:HyperLink>
</asp:Content>
