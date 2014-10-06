<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchDataBase.aspx.cs" Inherits="SearchEngine.SearchDataBase" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="lnkAddToDataBase" runat="server" NavigateUrl="~/Default.aspx"
        Text="Back" /><br />
    <br />
    <asp:Label ID="lblInto" runat="server" Text="Please enter a word or sentence to search the database"
        ForeColor="Black" /><br />
    <br />    
    <asp:TextBox ID="tbSearchCriteria" Width="300" runat="server" /><asp:Button ID="btnSearch"
        runat="server" Text="Search" OnClick="btnSearch_Click"  ValidationGroup="Search" /> <asp:RequiredFieldValidator ID="rfvSearch" runat="server" ValidationGroup="Search" ForeColor="Red" ControlToValidate="tbSearchCriteria" ErrorMessage="Required field empty" /><br />
    <br />   
    <asp:Label ID="lblResult" runat="server" Text="Search Results:" Font-Bold="true" ForeColor="Black" /><br />
    <br />      
    <div id="divResults" runat="server" visible="false" style="color: Black;" >
    </div>
        <br /><br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"/>
</asp:Content>
