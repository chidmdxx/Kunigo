<%@ Page Language="C#" MasterPageFile="~/Chid.Master" AutoEventWireup="true" CodeBehind="survey.aspx.cs" Inherits="Tesis.survey" %>

<%@ Register TagPrefix="Chid" TagName="SurveyItem" Src="~/WebControl/SurveyItem.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="bodyholder">

    <div class="survey">
        <asp:Panel ID="surveydata" runat="server" EnableViewState="true">
        </asp:Panel>
        <asp:Button runat="server" OnClick="Unnamed_Click" Text="Submit" />
    </div>

</asp:Content>

