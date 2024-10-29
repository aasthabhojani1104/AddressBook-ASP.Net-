<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryAdd.aspx.cs" Inherits="AddressBook.Country.CountryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container pt-4 col-6">
    <h3>Country Add/Edit </h3>
    <hr />
    <div class="form-row">
        <asp:Label runat="server" ID="lblMessage" ForeColor="Green"></asp:Label>
            <div class="form-group">
                <asp:label runat="server" ID="lblCountryName" CssClass="form-label"><span class="text-danger">*</span>Country Name</asp:label><br />
                <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control"></asp:TextBox>
            </div><br />
            <div class="form-group">
                <asp:label runat="server" ID="lblCountryCode" ><span class="text-danger">*</span>Country Code</asp:label><br />
                <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div class="form-group">
                <asp:Button runat="server" ID="BtnSave" Text="Save" class="btn btn-success" OnClick="BtnSave_Click" />
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Country/Countrylist.aspx" CssClass="btn btn-danger"></asp:HyperLink>
            </div>
    </div>
</div>

</asp:Content>
