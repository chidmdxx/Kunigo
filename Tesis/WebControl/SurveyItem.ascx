<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="SurveyItem.ascx.cs" Inherits="Tesis.WebControl.SurveyItem" %>
<asp:Label ID="label" runat="server" ></asp:Label><br />
<asp:RadioButtonList ID="buttonlist" runat="server">
    <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
    <asp:ListItem Text="No" Value="1"></asp:ListItem>
    <asp:ListItem Text="Don't mind" Value="2"></asp:ListItem>
</asp:RadioButtonList>