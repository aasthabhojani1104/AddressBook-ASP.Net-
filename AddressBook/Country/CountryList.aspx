<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="AddressBook.Country.CountryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container pt-4 col-6">
      <h3>Country List</h3>
             <asp:HyperLink runat="server" ID="hladd" CssClass="btn btn-primary" Text="Add to List" NavigateUrl="~/Country/CountryAdd.aspx"></asp:HyperLink>
<%--      <asp:Button runat="server" ID="BtnAdd" CssClass="btn btn-info" Text="Add"  OnClick="BtnAdd_Click"/>--%>
     <hr />
     <asp:Label runat="server" ID="lblMessage"></asp:Label>
     <table class="table">
         <asp:Repeater runat="server" ID="rptCountryList" OnItemCommand="rptCountryList_ItemCommand">
              <HeaderTemplate>
                 <tr>
                     <th scope="col">Country Name</th>
                     <th scope="col">Country Code</th>
                     <th scope="col">Creation Date</th>
                     <th scope="col">Action</th>
                 </tr>
             </HeaderTemplate>
             <ItemTemplate>
                 <tr>
                     <td scope="row"><%# Eval("CountryName") %></td>
                     <td><%# Eval("CountryCode") %></td>
                     <td><%# Eval("CreationDate") %></td>
                     <td>
                         <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-primary" Text="Edit"  CommandName="Edit" CommandArgument='<%# Eval("CountryID") %>'/>
                         <asp:Button runat="server" ID="btnDelete"  CssClass="btn btn-danger"  Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("CountryID") %>'/>
                     </td>
                 </tr>
             </ItemTemplate>
       </asp:Repeater>
     </table>
 </div>

</asp:Content>
 