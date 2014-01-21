<%@ Page Language="C#" MasterPageFile="~/Chid.Master" AutoEventWireup="true" CodeBehind="feed.aspx.cs" Inherits="Tesis.feed" %>

<%@ Register TagPrefix="Chid" TagName="ImageItem" Src="~/WebControl/ImageItem.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="bodyholder">

    <div>
        <asp:ListView ID="feedpanel" runat="server">
            <ItemTemplate>
                <asp:UpdatePanel runat="server" ViewStateMode="Enabled" EnableViewState="true">
                    <ContentTemplate>
                        <div class="post">
                            <h2>
                                <asp:Label ID="titlelabel" runat="server" Text='<%# Eval("title") %>'/></h2>
                            <asp:Image ID="image" CssClass="imagepost" runat="server" ImageUrl='<%# Eval("url") %>' />
                            <div class="votes">
                                <asp:ImageButton runat="server" CssClass="unselected" ImageUrl="~/Content/images/like.png" ID="like" OnCommand="like_Command" CommandName="like"  CommandArgument='<%# Eval("subreddit") + "," + Eval("id") %>'/>
                                <asp:ImageButton runat="server" CssClass="unselected" ImageUrl="~/Content/images/dislike.png" ID="dislike"  OnCommand="like_Command" CommandName="dislike"  CommandArgument='<%# Eval("subreddit") + "," + Eval("id") %>'/>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <!--<Chid:ImageItem ID="imageitem" runat="server" Idd='<%# Eval("id") %>' ImageUrl='<%# Eval("url") %>' Type='<%# Eval("subreddit") %>' Title='<%# Eval("title") %>' />-->
            </ItemTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="feedpanel"
            PageSize="10" OnPreRender="DataPagerProducts_PreRender">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="false" ShowPreviousPageButton="true" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>

