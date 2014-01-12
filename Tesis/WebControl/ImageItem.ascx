<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageItem.ascx.cs" Inherits="Tesis.WebControl.ImageItem" %>

<asp:Image ID="image" runat="server" />
<div class="votes">
    <asp:Button runat="server" ID="like"  OnClientClick="javascript:return false;" OnClick="like_Click"/>
    <asp:Button runat="server" ID="dislike" OnClientClick="javascript:return false;" OnClick="dislike_Click"/>
</div>