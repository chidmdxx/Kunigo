<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageItem.ascx.cs" Inherits="Tesis.WebControl.ImageItem" %>
<asp:UpdatePanel runat="server" ViewStateMode="Enabled" EnableViewState="true">
    <ContentTemplate>
        <div class="post">
            <h2><asp:Label ID="titlelabel" runat="server"/></h2>
            <asp:Image ID="image" CssClass="imagepost" runat="server" />
            <div class="votes">
                <asp:ImageButton runat="server" CssClass="unselected" ImageUrl="~/Content/images/like.png" ID="like" OnClick="like_Click" />
                <asp:ImageButton runat="server" CssClass="unselected" ImageUrl="~/Content/images/dislike.png" ID="dislike" OnClick="dislike_Click" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
