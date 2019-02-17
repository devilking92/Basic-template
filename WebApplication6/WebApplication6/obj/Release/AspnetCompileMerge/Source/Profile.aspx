<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication6.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Profile</h4>
        <hr />
        <div class="row">
            <div class="col-sm-offset-4 col-sm-2">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="UpdateError" />
                </p>
                <p class="text-success">
                    <asp:Literal runat="server" ID="UpdateCorrect"/>
                </p>    
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-4 control-label">Потребителско име</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-4 control-label">Специалност</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserSpec" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-4 control-label">Курс</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserKurs" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-4 col-md-12">
                <asp:Button runat="server" OnClick="UpdateUser_Click" Text="Update" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
