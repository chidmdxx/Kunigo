<%@ Page Language="C#" MasterPageFile="~/Chid.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tesis.index" %>

<asp:Content ContentPlaceHolderID="head" runat="Server">
    <meta name="login" content="Welcome" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="bodyholder">

    <div class="login">
        <asp:Label runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="username" runat="server"></asp:TextBox><br />
        <asp:Label runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button runat="server" Text="LogIn" OnClick="login_Click" /><br />
        <asp:Label ID="errorlogin" CssClass="error" runat="server" Text="The username or password doesn't match" Visible="false"></asp:Label>
    </div>
    <div class="signup">
        <asp:Label runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="usernamesign" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server"
            ControlToValidate="usernamesign"
            ErrorMessage="Don't use blank spaces in username"
            ValidationExpression="[^\s]{1,50}" /><br />
        <asp:Label runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="passwordsign" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server"
            ControlToValidate="passwordsign"
            ErrorMessage="Minimum password length is 5 non blank characters"
            ValidationExpression="[^\s]{5,50}" /><br />
        <asp:Label runat="server" Text="Confirm password"></asp:Label>
        <asp:TextBox ID="password2sign" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator runat="server"
            ControlToValidate="password2sign"
            ControlToCompare="passwordsign"
            ErrorMessage="Passwords do not match." /><br />
        <asp:Button runat="server" Text="Register" OnClick="register_Click" />
        <asp:Label ID="usernametaken" CssClass="error" runat="server" Text="The username is already taken" Visible="false"></asp:Label>
    </div>

</asp:Content>

