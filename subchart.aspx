<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="subchart.aspx.cs" Inherits="MyProject.subchart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 123px;
            height: 202px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>SUBSIDY CHART 
    </h1>

     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:shopingConnectionString1 %>"
            
            SelectCommand="SELECT top 1 day as b,image as im from [schart]">
    </asp:SqlDataSource>
   
    <asp:DataList ID="DataList1"  runat="server" DataSourceID="SqlDataSource1" 
            onitemdatabound="sd" EnableViewState="False" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal"  >
            <AlternatingItemStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <ItemTemplate>
                
                <asp:Image ID="Image1" runat="server"   ImageUrl='<%# Eval("im") %>' Height="100%" Width="100%" />
                &emsp;&emsp;<br />
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("b") %>' />&emsp;
                </ItemTemplate>
        </asp:DataList>
    
            
       


     

    


    </asp:Content>