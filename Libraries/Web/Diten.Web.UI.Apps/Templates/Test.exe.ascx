<%@ control language="C#" autoeventwireup="true" codebehind="Test.exe.ascx.cs" inherits="Diten.Web.UI.Apps.Templates.Test" %>
<diten:ContentPanel ID="PanelContent" runat="server">
	<Items>
		<ext:TabPanel runat="server" ActiveTabIndex="0" BodyStyle="padding:5px;">
			<TopBar>
				<ext:Toolbar runat="server">
					<Items>
					</Items>
				</ext:Toolbar>
			</TopBar>
			<Items>
				<diten:Panel ID="P1" runat="server" Title="Tab Text 1" Border="false" Html="<p>Something useful would be in here.</p>">
					<Items>
						<diten:SearchTextField runat="server" ID="SearchTextField" Text="This is a test"/>
					</Items>
				</diten:Panel>

				<diten:Panel ID="P2" runat="server" Title="Tab Text 2" Border="false" Html="<p>Something useful would be in here.</p>">
				</diten:Panel>

				<diten:Panel ID="P3" runat="server" Title="Tab Text 3" Border="false" Html="<p>Something useful would be in here.</p>">
				</diten:Panel>

				<diten:Panel ID="P4" runat="server" Title="Tab Text 4" Border="false" Html="<p>Something useful would be in here.</p>">
				</diten:Panel>
			</Items>
		</ext:TabPanel>
	</Items>
</diten:ContentPanel>