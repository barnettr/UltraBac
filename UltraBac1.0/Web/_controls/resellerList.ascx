<%@ Control Language="C#" AutoEventWireup="true" CodeFile="resellerList.ascx.cs" Inherits="_controls_resellerList" %>

<asp:AccessDataSource ID="accDealerCountries" runat="server" 
    DataFile="~/App_Data/resellers/db-dealers.mdb" 
    SelectCommand="SELECT DealerCountry FROM [tblDealer] WHERE ([ShowLive] = ?) GROUP BY [DealerCountry] ORDER BY [DealerCountry]='USA', [DealerCountry]">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="ShowLive" Type="String" />
    </SelectParameters>
</asp:AccessDataSource>

<asp:Repeater ID="repCountries" runat="server" 
    DataSourceID="accDealerCountries">
    <ItemTemplate>
        <div>
            <asp:LinkButton ID="btnCountry" runat="server" OnClick="btnCountry_Click" Text='<%# Eval("DealerCountry") %>' />
        </div>
    </ItemTemplate>
</asp:Repeater>

<asp:PlaceHolder ID="plhDealerList" runat="server">
    <div>
        <asp:Label ID="lblCountryName" runat="server" />
    </div>
    
    <asp:Label ID="lblNoResults" runat="server" Visible="false">No UltraBac resellers were found in this country. Please <a href='javascript: history.go(-1);'>try again</a>.</asp:Label>
    
    <asp:AccessDataSource ID="accDealers" runat="server" 
        DataFile="~/App_Data/resellers/db-dealers.mdb" 
        SelectCommand="SELECT * FROM [tblDealer] WHERE (([ShowLive] = ?) AND ([DealerCountry] = ?)) ORDER BY [DealerName]">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="ShowLive" Type="String" />
        </SelectParameters>
    </asp:AccessDataSource>

    <asp:Repeater ID="repDealers" runat="server" OnItemDataBound="repDealers_ItemDataBound">
        <ItemTemplate>
            <div>
                <asp:HyperLink ID="hlkDealerName" runat="server" Visible="false" NavigateUrl='<%# Eval("DealerURL") %>' Target="_blank" ><%# Eval("DealerName") %></asp:HyperLink>
                <asp:Label ID="lblDealerName" runat="server" Visible="false"><%# Eval("DealerName") %></asp:Label>
                <br />
                <asp:Label ID="lblDealerLocation" runat="server" />
                <br />
                <asp:Label ID="lblDealerPhones" runat="server" />
            </div>
            <div>
                
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:PlaceHolder>