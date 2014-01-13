<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageItem.ascx.cs" Inherits="Tesis.WebControl.ImageItem" %>

<asp:Image ID="image" CssClass="post" runat="server" />
<div class="votes">
    <asp:ImageButton runat="server" ImageUrl="~/Content/images/like.png" ID="like"  OnClientClick="javascript:return false;" OnClick="like_Click"/>
    <asp:ImageButton runat="server" ImageUrl="~/Content/images/dislike.png" ID="dislike" OnClientClick="javascript:return false;" OnClick="dislike_Click"/>
</div>