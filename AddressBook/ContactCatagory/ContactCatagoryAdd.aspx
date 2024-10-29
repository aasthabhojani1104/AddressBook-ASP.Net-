<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCatagoryAdd.aspx.cs" Inherits="AddressBook.ContactCatagory.ContactCategoryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container pt-4 col-6">
    <h3>ContactCategory Add/Edit </h3>
    <hr />
    <div class="form-row">
        <asp:Label runat="server" ID="lblMessage" ForeColor="Green"></asp:Label>
        <div class="form-row">
            <%--<label><span class="text-danger">*</span>Select ContactCategory</label>--%>
           <%-- <asp:DropDownList runat="server" ID="ddlCountry" class="form-control">
            </asp:DropDownList>--%>
        </div>
       <div class="form-group">
            <label><span class="text-danger">*</span>ContactCategory Name</label>
            <asp:TextBox runat="server" ID="txtContactCategory" placeholder="Enter ContactCategory Name" EnableViewState="false" class="form-control"></asp:TextBox>
<%--            <asp:RequiredFieldValidator runat="server" ErrorMessage="*ContactCategory Name is Required." Display="Dynamic" ForeColor="Red" ControlToValidate="txtContactCategory"></asp:RequiredFieldValidator>--%>
<%--            <asp:RegularExpressionValidator ID="regContactCategory" runat="server" ErrorMessage="*ContactCategory Name Must be in Character" ForeColor="Red" ControlToValidate="txtContactCategory" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>--%>

        </div>
     <%--   <div class="form-group">
            <label for="inputCity"><span class="text-danger">*</span>ContactCategory ID</label>
            <asp:TextBox runat="server" ID="txtContactCategoryCode" class="form-control" placeholder="Enter ContactCategory ID" EnableViewState="false"></asp:TextBox>
<%--            <asp:RequiredFieldValidator runat="server" ErrorMessage="*ContactCategory ID is Required." ForeColor="Red" Display="Dynamic" ControlToValidate="txtContactCategoryCode"></asp:RequiredFieldValidator>
<%--            <asp:RegularExpressionValidator ID="regCountryCode" runat="server" ErrorMessage="*Country Code Must be in 6 Digit." ForeColor="Red" ControlToValidate="txtContactCategoryCode" ValidationExpression="^\d{6}$"></asp:RegularExpressionValidator>--%>
        </div>
        <br />
        <div class="form-group">
            <asp:Button runat="server" ID="btnSave" Text="Save" class="btn btn-success" OnClick="btnSave_Click" />
            <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/ContactCatagory/ContactCatagoryList.aspx" CssClass="btn btn-danger"></asp:HyperLink>
        </div>
    </div>
</div>
</asp:Content>
