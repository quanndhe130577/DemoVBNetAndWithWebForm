<%@ Page Title="Edit Treatment" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTreatment.aspx.vb" Inherits="DemoV.s1.EditTreatment" %>


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
   <h3 style="color: blue; font-weight: bold">Edit treatment information</h3>
   <input type="hidden" id="hiddenTreatmentId" runat="server" />
   <table style="margin-left: auto; margin-right: auto; width: 50%">
      <tr>
         <td class="tdLabel" style="width: 30%">Clinic :</td>
         <td class="tdInput">
            <asp:DropDownList CssClass="dropDownClinic" runat="server" ID="dropDownListClinic" onchange="HideResultInput()"></asp:DropDownList>
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Patient :</td>
         <td class="tdInput">
            <asp:DropDownList CssClass="dropDownPatient" runat="server" ID="dropDownPatient" onchange="HideResultInput()"></asp:DropDownList>
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Visit date :</td>
         <td class="tdInput">
            <input required id="inputDate" type="date" runat="server" style="width: 50%" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Desctiption :</td>
         <td class="tdInput">
            <input id="inputDes" type="text" runat="server" onchange="HideResultInput()" />
         </td>
      </tr>
      <tr>
         <td class="tdLabel">Cost :</td>
         <td class="tdInput">
            <input required id="inputCost" type="number" runat="server" onchange="HideResultInput()" />
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
   <asp:HyperLink CssClass="hyperLinkBack" NavigateUrl="~/Features/Treatments/TreatmentManagement.aspx" runat="server">Back to Treatment Management</asp:HyperLink>
</asp:Content>
