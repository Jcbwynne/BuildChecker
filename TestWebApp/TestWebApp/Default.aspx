<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/FreeWall.js"></script>
    
    <asp:UpdatePanel runat="server" ID="itemsandchamp" UpdateMode="Always">
        <ContentTemplate>
            <asp:ImageButton runat="server" ID="ShowChampsButton" ImageUrl="~/Resources/Face.png" CssClass="roundedcorners ChampionImage" OnClick="showChamps_Click"/>
            <asp:ImageButton runat="server" id="ItemSlot1" ImageUrl="~/Resources/emptyItemSlot.png" CssClass="roundedcorners ItemSlot1"/>
            <asp:ImageButton runat="server" id="ItemSlot2" ImageUrl="~/Resources/emptyItemSlot.png" CssClass="roundedcorners ItemSlot2"/>
            <asp:ImageButton runat="server" id="ItemSlot3" ImageUrl="~/Resources/emptyItemSlot.png" CssClass="roundedcorners ItemSlot3"/>
            <asp:ImageButton runat="server" id="ItemSlot4" ImageUrl="~/Resources/emptyItemSlot.png" CssClass="roundedcorners ItemSlot4"/>
            <asp:ImageButton runat="server" id="ItemSlot5" ImageUrl="~/Resources/emptyItemSlot.png" CssClass="roundedcorners ItemSlot5"/>
            <asp:ImageButton runat="server" id="ItemSlot6" ImageUrl="~/Resources/emptyItemSlot.png" CssClass="roundedcorners ItemSlot6"/>
            <asp:ImageButton runat="server" id="ShowItemsButton" ImageUrl="~/Resources/Shopkeeper.png" CssClass="roundedcorners ItemShop" OnClick="showItems_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:Panel runat="server" ID="SummaryPanel" >
        <asp:Label runat="server" ID="selectedChamp" />
        <asp:Panel runat="server" ID="itemModifierPanel">

        </asp:Panel>
        <asp:UpdatePanel runat="server" ID="champStatisticPanel" EnableViewState="true" >
            <ContentTemplate>
                <div id="champstats">
                    <div runat="server" id="abilitypower"/>
                    <div runat="server" id="armor"/>
                    <div runat="server" id="armorperlevel"/>
                    <div runat="server" id="attackdamage"/>
                    <div runat="server" id="attackdamageperlevel"/>
                    <div runat="server" id="attackrange"/>
                    <div runat="server" id="attackspeedoffset"/>
                    <div runat="server" id="attackspeedperlevel"/>
                    <div runat="server" id="crit"/>
                    <div runat="server" id="critperlevel"/>
                    <div runat="server" id="hp"/>
                    <div runat="server" id="hpperlevel"/>
                    <div runat="server" id="hpregen"/>
                    <div runat="server" id="hpregenperlevel"/>
                    <div runat="server" id="movespeed"/>
                    <div runat="server" id="mp"/>
                    <div runat="server" id="mpperlevel"/>
                    <div runat="server" id="mpregen"/>
                    <div runat="server" id="mpregenperlevel"/>
                    <div runat="server" id="spellblock"/>
                    <div runat="server" id="spellblockperlevel"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>


    <asp:updatepanel id="championPopUps" runat="server" updatemode="Always">
        <contenttemplate>
            <asp:panel id="championPanelOverlay" runat="server" CssClass="Overlay" visible="false">
                <asp:panel id="championPopupQuit" runat="server" CssClass="PopUpPanel" visible="false">
                    <asp:Button runat="server" Text="X" OnClick="hideChamps_Click" />
                    <asp:panel id="championgPanelPopUpPanel" runat="server" CssClass="SubPopupPanel" visible="false">
                        <asp:panel id="championPanelPopUpTitle" runat="server" CssClass="TileGrid"/>
                    </asp:panel>
                </asp:panel>
            </asp:panel>
        </contenttemplate>
    </asp:updatepanel>


    <asp:updatepanel id="itemUpdatePanel" runat="server" updatemode="Always">
        <contenttemplate>
            <asp:panel id="itemPanelOverlay" runat="server" CssClass="Overlay" visible="false" >
                <asp:Panel id="itemPopupQuit" runat="server" CssClass="PopUpPanel" Visible="false">
                    <asp:Button runat="server" Text="X" OnClick="hideItems_Click" />
                    <asp:panel id="itempanelPopUpPanel" runat="server" CssClass="SubPopupPanel" visible="false">
                        <asp:panel id="itemPanelPopUpTitle" runat="server" />
                    </asp:panel>
                </asp:Panel>
            </asp:panel>
        </contenttemplate>
    </asp:updatepanel>

</asp:Content>
