<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/ForUsers.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication6._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <%string isAdmin = (string)(Session["Admin"]);
        if (isAdmin == "1")
        { %>
            <div class="button-slide">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Slider options</button>
            </div>
            <div id="demo" class="collapse">
                <div class="row button-slide">
                    <div class="col-md-6 upload-button-panel">
                        <div class="form-horizontal">
                            <h4>Use a local account to log in.</h4>
                            <hr />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="imgHeaderBox" CssClass="col-sm-2 control-label">Header</asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="imgHeaderBox" CssClass="form-control"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="imgContentBox" CssClass="col-sm-2 control-label">Content</asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="imgContentBox" CssClass="form-control"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <label class="btn btn-default btn-file">
                                      <asp:FileUpload ID="SliderImgUpload" runat="server" />
                                    </label>
                                    <asp:Button OnClick="SliderBtnImgUpload" runat="server" Text="Upload" CssClass="btn btn-default"/>
                                    <asp:Label ID="SliderLabelMessage" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" HorizontalAlign="Center" CssClass="sliderImageTable" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                            <Columns>
                                <asp:TemplateField HeaderText="Image Name">
                                    <ItemTemplate>
                                        <asp:Label ID="imgLabelID" runat="server" Text='<%#Eval("imgID") %>' Visible="false"></asp:Label>
                                       <asp:Image CssClass="SliderEditImg" ID="img" runat="server" ImageUrl='<%#Eval("imgName","Content/Images/{0}") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button ID="imgDelete" runat="server" CommandName="Delete" Text="Delete"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
     <% } %>
    <div class="jumbotron">
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
           
          <!-- Wrapper for slides -->
          <div class="carousel-inner" role="listbox">
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <div class='item <%#Container.ItemIndex==0?"active":"" %>'>
                       <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("imgName","Content/Images/{0}") %>' />
                       <div class="carousel-caption">
                        <h3>
                            <asp:Label ID="imgHeaderLabel" runat="server" Text='<%#Eval("imgHeader") %>'></asp:Label>
                        </h3>
                        <p>
                            <asp:Label ID="imgContentLabel" runat="server" Text='<%#Eval("imgContent") %>'></asp:Label>
                        </p>
                       </div>
                    </div>
                 </ItemTemplate>
             </asp:Repeater>
          </div>

          <!-- Controls -->
          <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
