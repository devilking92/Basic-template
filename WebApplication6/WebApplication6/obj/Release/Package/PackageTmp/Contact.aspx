<%@ Page Title="Contact" Language="C#" MasterPageFile="~/ForUsers.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication6.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="pageHeader">Contact me if you need help</h1>
    
    <div class="row">
        <div class="col-sm-12">
            <div class="col-sm-1 center">
                <i class="fa fa-html5 fa-3x fa-fw" aria-hidden="true"></i>
            </div>
            <div class="col-sm-5">
                <h5>Front-End developer: Gyuner Zekerie</h5>
            </div>
             <div class="col-sm-1 center">
                <i class="fa fa-cog fa-spin fa-3x fa-fw" aria-hidden="true"></i>
            </div>
            <div class="col-sm-5">
                <h5>Back-End developer: Gyuner Zekerie</h5>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="col-sm-1 center">
                <span class="fa-stack fa-2x">
                  <i class="fa fa-square fa-stack-2x"></i>
                  <i class="fa fa-terminal fa-stack-1x fa-inverse"></i>
                </span>
            </div>
            <div class="col-sm-5">
                <address>
                    Self production<br />
                    city: Shumen, bul. Madara №26<br />
                    <abbr title="Phone">P:</abbr>
                    0893966940
                </address>
            </div>
             <div class="col-sm-1 center">
                <i class="fa fa-envelope-o fa-3x fa-fw" aria-hidden="true"></i>
            </div>
            <div class="col-sm-5">
                <address>
                    <strong>Support:</strong><a href="mailto:guner.zekerie@abv.bg">guner.zekerie@abv.bg</a><br />
                </address>
            </div>
        </div>
    </div>
</asp:Content>
