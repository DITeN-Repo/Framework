<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiBrow.exe.ascx.cs" Inherits="Diten.Web.UI.Apps.Browser.DiBrow" %>

<diten:ApplicationPanel runat="server" Width="800" Height="600">
	<TopBar>
		<diten:Toolbar runat="server">
			<Items>
				<diten:Button ID="ButtonBack" runat="server" Icon="PageBack" ToolTip="Go back one page"/>
				<diten:Button ID="ButtonForward" runat="server" Icon="PageBack" ToolTip="Go forward one page"/>
				<diten:Button ID="ButtonRefresh" runat="server" Icon="PageRefresh" ToolTip="Reload current page"/>
				<diten:Button ID="ButtonHome" runat="server" Icon="ApplicationHome" ToolTip="Reload current page"/>
				<diten:TextField ID="TextFieldAddressBar" runat="server"/>
			</Items>
		</diten:Toolbar>
	</TopBar>
	<Items>
		<diten:Browser ID="Browser" runat="server"/>
	</Items>
</diten:ApplicationPanel>