<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="survey.aspx.cs" Inherits="Tesis.survey" %>

<%@ Register TagPrefix="Chid" TagName="SurveyItem" Src="~/WebControl/SurveyItem.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="surveydata" runat="server"  EnableViewState="true">

            </asp:Panel>
            <asp:Button runat="server" OnClick="Unnamed_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
