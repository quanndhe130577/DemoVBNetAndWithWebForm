<%@ Page Title="New Treatment" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewTreatment.aspx.vb" Inherits="DemoV.s1.NewTreatment" %>

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
   <h3 style="color: blue; font-weight: bold">New treatment information</h3>
   <table style="margin-left: auto; margin-right: auto; width: 50%">
      <tr>
         <td class="tdLabel" style="width: 30%">Clinic :</td>
         <td class="tdInput">
            <asp:DropDownList CssClass="dropDownClinic" runat="server" ID="dropDownListClinic"></asp:DropDownList>
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Patient :</td>
         <td class="tdInput">
            <asp:DropDownList CssClass="dropDownPatient" runat="server" ID="dropDownPatient"></asp:DropDownList>
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Visit date :</td>
         <td class="tdInput">
            <input required id="inputDate" type="date" runat="server" style="width: 50%" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Desctiption :</td>
         <td class="tdInput">
            <input id="inputDes" type="text" runat="server" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Cost :</td>
         <td class="tdInput">
            <input required id="inputCost" type="number" runat="server" />
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
   <asp:HyperLink NavigateUrl="~/Features/Treatments/TreatmentManagement.aspx" runat="server" CssClass="hyperLinkBack">Back to Treatment Management</asp:HyperLink>
</asp:Content>
