<%@ Page Language="C#" MasterPageFile="~/Site1.Master"AutoEventWireup="true" CodeBehind="export.aspx.cs" Inherits="MyProject.export" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 272px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">







    <h2>CLICK HERE TO GET PURCHASE DETAILS </h2>
    <asp:Button Text="Export" OnClick="ExportExcel" runat="server" />
</asp:Content>