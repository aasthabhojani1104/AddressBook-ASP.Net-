<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateList.aspx.cs" Inherits="AddressBook.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container pt-4 col-6">
        <h3>State List</h3>
        <hr />
        <table class="table">
      <asp:HyperLink runat="server" ID="hladd" CssClass="btn btn-primary" Text="Add to List" NavigateUrl="~/State/StateAdd.aspx"></asp:HyperLink>
<%--            <asp:Button ID="btn" runat="server" Text="Add to List" CssClass="btn btn-primary" OnClick="btnAdd_Click"  />--%>
            <asp:Repeater runat="server" ID="rptStateList" OnItemCommand="rptStateList_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <th scope="col">Country Name</th>
                        <th scope="col">State Name</th>
                        <th scope="col">State Code</th>
                        <th scope="col">Action</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td scope="row"><%# Eval("CountryName") %></td>
                        <td><%# Eval("StateName") %></td>
                        <td><%# Eval("StateCode") %></td>
                        <td><%# Eval("StateID") %></td>
                        <td>
                            <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-primary" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("StateID") %>' />
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("StateID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
