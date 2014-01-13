<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageItem.ascx.cs" Inherits="Tesis.WebControl.ImageItem" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="post">
            <asp:Image ID="image" CssClass="imagepost" runat="server" />
            <div class="votes">
                <asp:ImageButton runat="server" ImageUrl="~/Content/images/like.png" ID="like" OnClick="like_Click" />
                <asp:ImageButton runat="server" ImageUrl="~/Content/images/dislike.png" ID="dislike" OnClick="dislike_Click" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
