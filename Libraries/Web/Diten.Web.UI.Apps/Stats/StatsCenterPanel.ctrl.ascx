<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatsCenterPanel.ctrl.ascx.cs" inherits="Diten.Web.UI.Apps.Stats.StatsCenterPanel" %>
<diten:Panel runat="server" ID="ContentPanel" Layout="Fit" Border="False">
	<Items>
		<diten:TabPanel runat="server" ID="TabPanelMain" TabPosition="Top" Layout="Fit" Border="False">
			<Items>
				<diten:Panel runat="server" ID="PanelWebStats" Title="IIS Stats" Layout="Fit" Border="False">
					<Items>
						<diten:TabPanel runat="server" ID="TabPanelWebSites" TabPosition="Top" Layout="Fit" Border="False"/>
					</Items>
				</diten:Panel>
			</Items>
		</diten:TabPanel>
	</Items>
</diten:Panel>