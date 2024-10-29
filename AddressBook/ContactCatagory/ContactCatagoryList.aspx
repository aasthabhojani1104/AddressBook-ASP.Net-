<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCatagoryList.aspx.cs" Inherits="AddressBook.ContactCatagory.ContactCategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container pt-4 col-6">
    <h3>Contact Category List</h3>
    <hr />
    <table class="table">
        <asp:HyperLink runat="server" ID="hladd" CssClass="btn btn-primary" Text="Add to List" NavigateUrl="~/ContactCatagory/ContactCatagoryAdd.aspx"></asp:HyperLink>
        <asp:Repeater runat="server" ID="rptContactCategoryList" OnItemCommand="rptContactCategoryList_IteamCommand">
            <HeaderTemplate>
                <tr>
                    <th scope="col">ContactCategory Name</th>
                    <th scope="col">ContactCategory ID</th>
                    
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td scope="row"><%# Eval("ContactCategoryName") %></td>
                    <td><%# Eval("ContactCategoryID") %></td>
                    <td>
                        <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-primary" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("ContactCategoryID") %>' />
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ContactCategoryID") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>

</asp:Content>
