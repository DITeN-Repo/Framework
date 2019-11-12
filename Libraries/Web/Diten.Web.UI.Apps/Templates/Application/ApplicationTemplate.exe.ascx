<%@ control language="C#" autoeventwireup="true" codebehind="ApplicationTemplate.exe.ascx.cs" inherits="Diten.Web.UI.Apps.Templates.Application.ApplicationTemplate" %>
<diten:ContentPanel runat="server" Layout="Fit" Border="False">
	<TopBar>
		<diten:Toolbar ID="Toolbar" runat="server" Border="False" Layout="Fit">
			<Items>
				<diten:TabPanel ID="TabPanelHolder" runat="server" Layout="Fit" Border="False">
					<Items>
						<diten:Panel ID="PanelHome" runat="server" Title="Home" Collapsible="True" CollapseMode="Mini" TitleCollapse="True" Border="False">
							<TopBar>
								<diten:ToolbarHome runat="server" ID="ToolbarHome" Border="False"/>
							</TopBar>
						</diten:Panel>
						<diten:Panel ID="PanelShare" runat="server" Title="Share" Collapsible="True" CollapseMode="Mini" TitleCollapse="True" Border="False">
							<TopBar>
								<diten:ToolbarShare runat="server" ID="ToolbarShare" Border="False"/>
							</TopBar>
						</diten:Panel>
						<diten:Panel ID="PanelJobs" runat="server" Title="Jobs" Collapsible="True" CollapseMode="Mini" TitleCollapse="True" Border="False">
							<Items>
								<diten:Toolbar runat="server" Border="False">
									<Items>
										<diten:ButtonGroup ID="ButtonGroupServerJobs" runat="server" Title="Server Jobs" Columns="4">
											<Items>
												<diten:Button ID="StatsButtonSetOdbcLogging" runat="server" Text="Set ODBC Logging" Scale="Large" IconAlign="Top" RowSpan="3" ToolTip="Set oDBC logging for all sites that hosted in IIS."/>
												<diten:Button ID="StatsButton2" runat="server" Text="Copy" Icon="PageCopy" Scale="Large" IconAlign="Top" RowSpan="3" ToolTip="Copy the selected items to clipboard (Ctrl+C)."/>
												<diten:Button ID="StatsButton3" runat="server" Text="Paste" Icon="PagePaste" Scale="Large" IconAlign="Top" RowSpan="3" ToolTip="Paste the contents of Clipboard to the current location. (Ctrl+V)"/>
												<diten:Button ID="StatsButton4" runat="server" Text="Cut" Icon="Cut" ToolTip="Move the selected items to the Clipboard. (Ctrl+X)"/>
												<diten:Button ID="StatsButton5" runat="server" Text="Copy path" Icon="PageCopy" ToolTip="Copy the path of selected items to the Clipboard."/>
												<diten:Button ID="StatsButton6" runat="server" Text="Paste shortcut" Icon="PagePaste" ToolTip="Paste shortcuts to the items on the Clipboard."/>
												<ext:Button runat="server" ID="ButtonTest" Text="Test" Icon="TelevisionStar">
													<DirectEvents>
														<Click OnEvent="Test_Click"></Click>
													</DirectEvents>
												</ext:Button>
											</Items>
											<Content>
											</Content>
										</diten:ButtonGroup>
									</Items>
								</diten:Toolbar>
							</Items>
						</diten:Panel>
					</Items>
				</diten:TabPanel>
			</Items>
		</diten:Toolbar>
	</TopBar>
	<Items>
		<diten:Panel ID="PanelHolder" runat="server" Border="false" Closable="false" Layout="Border">
			<Items>
				<diten:Panel ID="NorthPanel" runat="server" Region="North" Collapsible="true" MinHeight="100" Split="true" Height="100" Title="Header" TitleCollapse="False" Floatable="false" Collapsed="True" Layout="Fit">
					<Items>
					</Items>
				</diten:Panel>
				<diten:Panel ID="WestPanel" runat="server" Region="West" Collapsible="False" Resizable="True" MinWidth="175" Width="200" MaxWidth="375" BodyPadding="5" Layout="Fit">
					<Items>
					</Items>
				</diten:Panel>
				<diten:Panel ID="CenterPanel" IDMode="Parent" runat="server" Collapsible="False" Region="Center" Border="False" BodyPadding="0" Layout="Fit">
					<Items>
						<diten:Explorer runat="server" ID="Explorer"/>
					</Items>
				</diten:Panel>
				<diten:Panel ID="EastPanel" runat="server" Region="East" Collapsible="False" Resizable="True" MinWidth="175" Width="200" MaxWidth="375" BodyPadding="5" Layout="Fit">
					<Items>
						<ext:FormPanel ID="StatusForm" runat="server" LabelWidth="75" ButtonAlign="Right" Border="false" Padding="10">
							<Defaults>
								<ext:Parameter Name="Anchor" Value="95%"/>
								<ext:Parameter Name="AllowBlank" Value="false" Mode="Raw"/>
								<ext:Parameter Name="SelectOnFocus" Value="true" Mode="Raw"/>
								<ext:Parameter Name="MsgTarget" Value="side"/>
							</Defaults>
							<Items>
								<ext:TextField runat="server" FieldLabel="Name" BlankText="Name is required"/>
								<ext:DateField runat="server" FieldLabel="Birthdate" BlankText="Birthdate is required"/>
							</Items>
							<Buttons>
								<diten:Button runat="server" Text="Save" Icon="Disk">
									<DirectEvents>
										<Click
											OnEvent="ButtonFormSave_Click"
											Before="var valid= #{StatusForm}.getForm().isValid(); if (valid) {#{StatusBar}.showBusy('Saving form...');} return valid;">
											<EventMask
												ShowMask="true"
												MinDelay="1000"
												Target="CustomTarget"
												CustomTarget="={#{StatusForm}.getEl()}"/>
										</Click>
									</DirectEvents>
								</diten:Button>
							</Buttons>
						</ext:FormPanel>
					</Items>
				</diten:Panel>
				<diten:Panel ID="SouthPanel" runat="server" Region="South" Collapsible="true" MinHeight="100" Split="true" Height="100" Title="Footer" TitleCollapse="False" Floatable="false" Collapsed="False" Layout="Fit">
					<Items>
					</Items>
					<Listeners>
						<AfterRender Handler="this.setTitle('');"/>
						<BeforeCollapse Handler="this.setTitle('');"/>
						<BeforeExpand Handler="this.setTitle(this.initialConfig.title);"/>
					</Listeners>
				</diten:Panel>
			</Items>
		</diten:Panel>
	</Items>
	<BottomBar>
		<ext:StatusBar ID="StatusBar" runat="server" DefaultText="Ready">
			<Items>
				<ext:ToolbarFill runat="server"/>
				<ext:ToolbarTextItem ID="wordCount" runat="server" Text="Words: 0"/>
				<ext:ToolbarSeparator runat="server"/>
				<ext:ToolbarTextItem ID="charCount" runat="server" Text="Chars: 0"/>
				<ext:ToolbarSeparator runat="server"/>
				<ext:ToolbarTextItem ID="clock" runat="server" Text=" "/>
				<ext:SegmentedButton runat="server">
					<Items>
						<diten:Button ID="ButtonViewDetail" runat="server" Icon="ApplicationViewDetail" Pressed="True">
						</diten:Button>
						<diten:Button ID="ButtonViewIcons" runat="server" Icon="ApplicationViewIcons">
						</diten:Button>
					</Items>
				</ext:SegmentedButton>
			</Items>
		</ext:StatusBar>
	</BottomBar>
</diten:ContentPanel>