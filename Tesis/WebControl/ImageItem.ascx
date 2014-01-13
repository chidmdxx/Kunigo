<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageItem.ascx.cs" Inherits="Tesis.WebControl.ImageItem" %>
<div class="post">
    <asp:Image ID="image" CssClass="imagepost" runat="server" />
    <div class="votes">
        <asp:ImageButton runat="server" ImageUrl="~/Content/images/like.png" ID="like" OnClientClick="javascript:return false;" OnClick="like_Click" />
        <asp:ImageButton runat="server" ImageUrl="~/Content/images/dislike.png" ID="dislike" OnClientClick="javascript:return false;" OnClick="dislike_Click" />
    </div>
</div>
