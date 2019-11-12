<%@ control language="C#" autoeventwireup="true" codebehind="TestTemplate.exe.ascx.cs" inherits="Diten.Web.UI.Apps.Templates.TestApp.TestTemplate" %>
<ext:DesktopModuleProxy ID="DesktopModuleProxy" runat="server">
	<Module>
		<Shortcut Name="Test Template"/>
		<Launcher Text="Test Template" Icon="Tab"/>
		<Window>
			<diten:Window ID="Window" runat="server"
			              Icon="Tab"
			              Width="740"
			              Height="480"
			              ConstrainHeader="true"
			              Border="false"
			              Layout="Fit"
			              Title="Tab Window">
				<TopBar>
					<diten:Toolbar ID="Toolbar" runat="server" Border="False" Layout="Fit">
						<Items>
							<diten:TabPanel ID="TabPanel" runat="server" Layout="Fit" Border="False">
								<Items>
									<diten:Panel ID="PanelHome" runat="server" Title="Home" Collapsible="True" CollapseMode="Mini" TitleCollapse="True" Border="False">
										<Items>
											<diten:Toolbar ID="PanelHomeToolbar" runat="server" Border="False">
												<Items>
													<diten:ButtonGroup ID="ButtonGroupHelp" runat="server" Title="Help" Columns="1">
														<Content>
															<%--<diten:KeyMap runat="server" Target="#{ContentPanel}">
                                                                        <Binding>
                                                                            <diten:KeyBinding Ctrl="True" Handler="#{DesktopApplicationTemplateButtonHelp}.fireEvent('click');">
                                                                                <Keys>
                                                                                    <diten:Key Code="H" />
                                                                                </Keys>
                                                                            </diten:KeyBinding>
                                                                        </Binding>
                                                                    </diten:KeyMap>--%>
														</Content>
														<Items>
															<ext:MenuSeparator ID="ButtonGroupHelpMenuSeparator" runat="server" Cls="MenuSeparator"/>
															<diten:SplitButton ID="ButtonHelp" Text="Help" runat="server" Icon="Help" ToolTip="Show help of current view." Scale="Large" RowSpan="3" IconAlign="Top" ArrowAlign="Right">
																<Menu>
																	<ext:Menu runat="server" ID="HelpMenu">
																		<Items>
																			<ext:MenuItem ID="MenuItemAboutDiten" runat="server" Text="About DITeN framework" Icon="Information" ToolTip="Show information about DITeN.">
																				<DirectEvents>
																					<Click OnEvent="MenuItemAboutDiten_Click"></Click>
																				</DirectEvents>
																			</ext:MenuItem>
																		</Items>
																	</ext:Menu>
																</Menu>
																<DirectEvents>
																	<Click OnEvent="ButtonHelp_Click">
																		<EventMask ShowMask="true" Target="CustomTarget" CustomTarget="ContentPanel" Msg="Show help"/>
																		<ExtraParams>
																			<ext:Parameter Name="HelpID" Value="Diten.Web.UI.WebControls.SystemControls.Explorer" Mode="Value"/>
																		</ExtraParams>
																	</Click>
																</DirectEvents>
															</diten:SplitButton>
														</Items>
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
					<diten:Panel ID="ContentPanel" runat="server" Border="false" Closable="false" Layout="Border">
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
									<diten:Button ID="ButtonViewDetail" runat="server" Icon="ApplicationViewDetail" Pressed="True" OnClick="ButtonViewDetail_Click"/>
									<diten:Button ID="ButtonViewIcons" runat="server" Icon="ApplicationViewIcons" OnClick="ButtonViewIcons_Click"/>
								</Items>
							</ext:SegmentedButton>
						</Items>
						<Plugins>
							<ext:ValidationStatus runat="server" FormPanelID="StatusForm" ValidIcon="Accept" ErrorIcon="Exclamation"/>
						</Plugins>
					</ext:StatusBar>
				</BottomBar>
			</diten:Window>
		</Window>
	</Module>
</ext:DesktopModuleProxy>