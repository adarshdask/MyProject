<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableViewState="true" Trace="true" CodeBehind="Addchart.aspx.cs" Inherits="MyProject.Addchart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 272px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <br /><br /> <br /><br /> 
    <table cellspacing=4 cellpadding=2 width=100%>
        <tr>
             <td class="style1">Browse subsidy chart  IMAGE </td>
            <td>
                <asp:FileUpload ID="FileUpload1"  runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="FileUpload1" ErrorMessage="show image path"></asp:RequiredFieldValidator>
   
                <asp:TextBox ID="textbox6" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="textbox6"
                    ErrorMessage="Please fill the date"   ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
        </table>
        <br /> <br /><br /> <br /><br /> 
            
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="SAVE" />










 </asp:Content>