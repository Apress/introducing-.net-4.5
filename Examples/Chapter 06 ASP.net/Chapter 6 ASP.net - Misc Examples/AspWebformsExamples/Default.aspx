<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspWebformsExamples._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                    <%: Page.Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>. The page features <mark>videos, tutorials, and samples</mark>to help you get the most from ASP.NET. If you have any questions about ASP.NET visit <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   

       <asp:FormView ID="FormView1" ItemType="AspWebformsExamples.Person" UpdateMethod="UpdatePeople" AllowPaging="true" runat="server" SelectMethod="GetPeople" DataKeyNames="ID" DefaultMode="Edit">
            <EditItemTemplate>
            <ol>
               <li>
               <%#Item.ID%>
               </li>

               <li>
                <asp:TextBox ID="textFirstName" runat="server" Text='<%# Item.FirstName %>' /></asp:TextBox>


               </li>
               <li>
               <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.LastName %>' /></asp:TextBox>
               </li>
            </ol>

           <%=  System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode("<script>alert('I wont run as im encoded!');</script>", false) %>
                <asp:FileUpload ID="uploadFile" runat="server"  AllowMultiple="true" />

                <asp:TextBox ID="TextBox2"  ValidateRequestMode="Disabled" runat="server"></asp:TextBox>

            <asp:linkbutton id="UpdateButton"
            text="Update"
            commandname="Update"
            runat="server"/>


            <asp:ValidationSummary ID="ValidationSummary1" runat="server"/>
            </EditItemTemplate>

     
     </asp:FormView>

          <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstname" ErrorMessage="Required"></asp:RequiredFieldValidator>


</asp:Content>
