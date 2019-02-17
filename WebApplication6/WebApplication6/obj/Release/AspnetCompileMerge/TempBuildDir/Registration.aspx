<%@ Page Title="Registration" Language="C#" MasterPageFile="~/ForUsers.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication6.Registration" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <!--
        username: webuser
        password: webuser2
    -->
    
    <h2><%//: Title %></h2>
    

    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">Потребителско име</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="Полето за потребителско име е задължително" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 control-label">Парола</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Полето за парола е задължително" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-4 control-label">Потвърждение на парола</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Полето за потвърждение на паролата е задължително" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Паролите не съвпадат" />
                <br />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserSpec" CssClass="col-md-4 control-label">Специалност</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserSpec" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserSpec"
                    CssClass="text-danger" ErrorMessage="Полето за специалност е задължително" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserKurs" CssClass="col-md-4 control-label">Курс</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="UserKurs" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserKurs"
                    CssClass="text-danger" ErrorMessage="Полето за курс е задължително" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="True">Права като администратор</asp:Label>
            <div class="col-sm-1">
                 <asp:CheckBox runat="server" id="UserAdmin" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-4 col-md-12">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Регистрация" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>