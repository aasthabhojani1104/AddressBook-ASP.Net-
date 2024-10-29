<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateAdd.aspx.cs" Inherits="AddressBook.StateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container pt-4 col-6">
        <h3>State Add/Edit </h3>
        <hr />
        <div class="form-row">
            <asp:Label runat="server" ID="lblMessage" ForeColor="Green"></asp:Label>
            <div class="form-row">
                <label><span class="text-danger">*</span>Select Country</label>
                <asp:DropDownList runat="server" ID="ddlCountry" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label><span class="text-danger">*</span>State Name</label>
                <asp:TextBox runat="server" ID="txtStateName" placeholder="Enter State Name" EnableViewState="false" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="*State Name is Required." Display="Dynamic" ForeColor="Red" ControlToValidate="txtStateName"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regStateName" runat="server" ErrorMessage="*State Name Must be in Character" ForeColor="Red" ControlToValidate="txtStateName" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>

            </div>
            <div class="form-group">
                <label for="inputCity"><span class="text-danger">*</span>State Code</label>
                <asp:TextBox runat="server" ID="txtStateCode" class="form-control" placeholder="Enter State code" EnableViewState="false"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="*State Code is Required." ForeColor="Red" Display="Dynamic" ControlToValidate="txtStateCode"></asp:RequiredFieldValidator>
            </div>
            <br />
            <div class="form-group">
                <asp:Button runat="server" ID="btnSave" Text="Save" class="btn btn-success" OnClick="btnSave_Click" />
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/State/StateList.aspx" CssClass="btn btn-danger"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
