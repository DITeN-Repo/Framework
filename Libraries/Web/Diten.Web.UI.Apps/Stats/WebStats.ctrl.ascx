<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebStats.ctrl.ascx.cs" inherits="Diten.Web.UI.Apps.Stats.WebStats" %>

<diten:Panel ID="ContentPanel" runat="server" Layout="Fit" Border="False">
<Items>
<diten:Panel Border="False"
             runat="server"
             Closable="false"
             Layout="Border">
<Items>
<diten:Panel Border="False" ID="CenterPanel" runat="server" Region="Center" Layout="Fit">
<Items>
<diten:TabPanel runat="server"
                ID="TabPanelCharts"
                TabPosition="Left"
                Border="False"
                AutoHeight="True">
<TopBar>
	<diten:Toolbar runat="server">
		<Items>
			<diten:PDateField ID="PDateFieldStartDate" FieldLabel="Start Date" runat="server">
				<DirectEvents>
					<Select OnEvent="PDateFieldStartDate_OnSelect">
						<EventMask ShowMask="True" Target="CustomTarget" CustomTarget="#{TabPanelMain}" Msg="Loading Data..."></EventMask>
					</Select>
				</DirectEvents>
			</diten:PDateField>
			<diten:PDateField ID="PDateFieldEndDate" FieldLabel="End Date" runat="server">
				<DirectEvents>
					<Select OnEvent="PDateFieldEndDate_OnSelect">
						<EventMask ShowMask="True" Target="CustomTarget" CustomTarget="#{TabPanelMain}" Msg="Loading Data..."></EventMask>
					</Select>
				</DirectEvents>
			</diten:PDateField>
			<ext:ToolbarFill runat="server"/>
		</Items>
	</diten:Toolbar>
</TopBar>
<Items>
<diten:Panel Border="False" ID="PanelVCByDate"
             runat="server"
             Layout="Fit"
             Title="VC By Date">
	<Items>
		<ext:CartesianChart Border="False" Layout="Absolute"
		                    ID="CartesianChartVCByDate"
		                    runat="server">
			<Store>
				<ext:Store
					runat="server"
					AutoDataBind="true">
					<Model>
						<ext:Model runat="server">
							<Fields>
								<ext:ModelField Name="VisitDate"/>
								<ext:ModelField Name="VisitCount"/>
							</Fields>
						</ext:Model>
					</Model>
				</ext:Store>
			</Store>
			<Axes>
				<ext:NumericAxis
					Position="Left"
					Fields="VisitCount"
					Grid="true"
					Title="Number of Hits"
					Minimum="0">
				</ext:NumericAxis>
				<ext:CategoryAxis Position="Bottom" Fields="VisitDate" Title="Date">
					<Label RotationDegrees="-45"></Label>
				</ext:CategoryAxis>
			</Axes>
			<Series>
				<ext:BarSeries
					Highlight="true"
					XField="VisitDate"
					YField="VisitCount">
					<Tooltip runat="server" TrackMouse="true">
						<Renderer Handler="toolTip.setTitle(record.get('VisitDate') + ': ' + record.get('VisitCount'));"/>
					</Tooltip>
				</ext:BarSeries>
			</Series>
		</ext:CartesianChart>
	</Items>
</diten:Panel>
<diten:Panel Border="False" runat="server"
             ID="Panel0_1000"
             Layout="Fit"
             Title="VC 0-1000">
	<Items>
		<diten:TabPanel runat="server"
		                ID="TabPanel0_1000"
		                TabPosition="Left"
		                Layout="Fit">
			<Items>
				<diten:Panel Border="False" ID="Panel0_10"
				             runat="server"
				             Layout="Fit"
				             Title="VC 0-10">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart0_10"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Title="Number of Hits"
									Minimum="0">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
				<diten:Panel Border="False" ID="Panel0_100"
				             runat="server"
				             Layout="Fit"
				             Title="VC 10-100">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart10_100"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Grid="true"
									Title="Number of Hits"
									Minimum="10">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
				<diten:Panel Border="False" ID="Panel100_500"
				             runat="server"
				             Layout="Fit"
				             Title="VC 100-500">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart100_500"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Grid="true"
									Title="Number of Hits"
									Minimum="100">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
				<diten:Panel Border="False" ID="Panel500_1000"
				             runat="server"
				             Layout="Fit"
				             Title="VC 500-1000">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart500_1000"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Grid="true"
									Title="Number of Hits"
									Minimum="500">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
			</Items>
		</diten:TabPanel>
	</Items>
</diten:Panel>
<diten:Panel Border="False" runat="server"
             ID="Panel1000_Infinity"
             Title="VC 1000-Infinity"
             Layout="Fit">
	<Items>
		<diten:TabPanel runat="server"
		                ID="TabPanel1000_Infinity"
		                TabPosition="Left"
		                Layout="Fit">
			<Items>
				<diten:Panel Border="False" ID="Panel1000_5000"
				             runat="server"
				             Layout="Fit"
				             Title="VC 1000-5000">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart1000_5000"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Grid="true"
									Title="Number of Hits"
									Minimum="1000">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
				<diten:Panel Border="False" ID="Panel15000_25000"
				             runat="server"
				             Layout="Fit"
				             Title="VC 5000-25000">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart5000_25000"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Grid="true"
									Title="Number of Hits"
									Minimum="5000">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
				<diten:Panel Border="False" ID="Panel25000_100000"
				             runat="server"
				             Layout="Fit"
				             Title="VC 25000-100000">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart25000_100000"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Grid="true"
									Title="Number of Hits"
									Minimum="25000">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
				<diten:Panel Border="False" ID="Panel100000_Infinity"
				             runat="server"
				             Layout="Fit"
				             Title="VC 100000-Infinity">
					<Items>
						<ext:CartesianChart Border="False" Layout="Absolute"
						                    ID="CartesianChart100000_Infinity"
						                    runat="server">
							<Store>
								<ext:Store
									runat="server"
									AutoDataBind="true">
									<Model>
										<ext:Model runat="server">
											<Fields>
												<ext:ModelField Name="ClientIp"/>
												<ext:ModelField Name="VisitCount"/>
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
							<Axes>
								<ext:NumericAxis
									Position="Left"
									Fields="VisitCount"
									Grid="true"
									Title="Number of Hits"
									Minimum="100000">
								</ext:NumericAxis>
								<ext:CategoryAxis Position="Bottom" Fields="ClientIp" Title="Client IP"/>
							</Axes>
							<Series>
								<ext:BarSeries
									Highlight="true"
									XField="ClientIp"
									YField="VisitCount">
									<Tooltip runat="server" TrackMouse="true">
										<Renderer Handler="toolTip.setTitle(record.get('ClientIp') + ': ' + record.get('VisitCount'));"/>
									</Tooltip>
								</ext:BarSeries>
							</Series>
						</ext:CartesianChart>
					</Items>
				</diten:Panel>
			</Items>
		</diten:TabPanel>
	</Items>
</diten:Panel>
</Items>
</diten:TabPanel>
</Items>
</diten:Panel>
<diten:Panel BorderSpec="10 5 10 3" ID="EastPanel" runat="server" Region="East" Collapsible="False" Resizable="False" Width="400" BodyPadding="5" Layout="Anchor">
	<Items>
		<diten:Panel ID="PanelInformation" Border="False" runat="server" Title="Information" AnchorHorizontal="100%" Height="80">
			<Items>
				<ext:TextField runat="server" ID="TextFieldTotalVisitCount" ReadOnly="True" FieldLabel="Total visit count"></ext:TextField>
				<ext:Label ID="LabelPanelInformationDescription" runat="server" Text="This is number of count of visitor IPs with no repetition of the Ip"></ext:Label>
			</Items>
		</diten:Panel>
		<diten:Panel ID="PanelMostVisitorInformation" Border="False" runat="server" Title="Most Visitor Information" AnchorHorizontal="100%" Height="110">
			<Items>
				<ext:TextField runat="server" ID="TextFieldMostVisitorIp" ReadOnly="True" FieldLabel="IP address"></ext:TextField>
				<ext:TextField runat="server" ID="TextFieldMostVisitorIpVisitCount" ReadOnly="True" FieldLabel="Visits in period"></ext:TextField>
				<ext:Label ID="LabelPanelMostVisitorInformationWebAddress" runat="server" Text="Web Address:"></ext:Label>
				<ext:Hyperlink runat="server" ID="HyperlinkMostVisitorWebAddress" Text="Indistinguishable" Disabled="True"></ext:Hyperlink>
			</Items>
		</diten:Panel>
		<diten:Panel ID="PanelTraceRoute" Border="False" runat="server" Title="Trace Route" AnchorHorizontal="100%" AnchorVertical="65%">
			<Items>
				<ext:ComboBox runat="server"
				              ID="ComboBoxIps"
				              FieldLabel="All IPs"
				              Editable="false"
				              DisplayField="ClientIp"
				              ValueField="VisitCount"
				              TypeAhead="true"
				              mode="Local"
				              ForceSelection="true"
				              EmptyText="Select an IP..."
				              SelectOnFocus="true"
				              Disabled="True">
					<Store>
						<ext:Store runat="server"
						           AutoDataBind="True">
							<Model>
								<ext:Model runat="server">
									<Fields>
										<ext:ModelField Name="ClientIp"/>
										<ext:ModelField Name="VisitCount"/>
									</Fields>
								</ext:Model>
							</Model>
						</ext:Store>
					</Store>
					<DirectEvents>
						<Select OnEvent="ComboBoxIps_OnSelect"></Select>
					</DirectEvents>
					<RightButtons>
						<ext:Button runat="server" ID="ButtonTrace" Text="Trace" Disabled="True">
							<DirectEvents>
								<Click OnEvent="ButtonTrace_Click"></Click>
							</DirectEvents>
						</ext:Button>
					</RightButtons>
				</ext:ComboBox>
				<ext:TextField runat="server" ID="TextFieldSelectedIpVisitCount" ReadOnly="True" FieldLabel="Total Visit Count"/>
				<ext:Label ID="LabelPanelTraceRouteVisitorURL" runat="server" Text="Visitor URL:"/>
				<ext:Hyperlink runat="server" ID="HyperlinkSelectedIpWebAddress" Text="Select an IP" Disabled="True"></ext:Hyperlink>
				<diten:ProgressBar runat="server" ID="ProgressBar" Interval="500" AutoRun="False" OnStart="#{ComboBoxIps}.setDisabled(true);#{ButtonLoadData}.setDisabled(true);#{PDateFieldEndDate}.setDisabled(true);#{PDateFieldStartDate}.setDisabled(true);" OnStop="#{ComboBoxIps}.setDisabled(false);#{ButtonLoadData}.setDisabled(false);#{PDateFieldEndDate}.setDisabled(false);#{PDateFieldStartDate}.setDisabled(false);"/>
				<ext:GridPanel runat="server" ID="GridPanelTracert" Scrollable="Vertical" Height="200">
					<Store>
						<ext:Store runat="server"
						           AutoDataBind="True">
							<Model>
								<ext:Model runat="server">
									<Fields>
										<ext:ModelField Name="Id" Type="Auto"></ext:ModelField>
										<ext:ModelField Name="Hop" Type="Auto"></ext:ModelField>
										<ext:ModelField Name="Time" Type="Auto"></ext:ModelField>
										<ext:ModelField Name="Host" Type="Auto"></ext:ModelField>
										<ext:ModelField Name="HostName" Type="Auto"></ext:ModelField>
									</Fields>
								</ext:Model>
							</Model>
						</ext:Store>
					</Store>
					<ColumnModel>
						<Columns>
							<ext:Column ID="ColumnId" runat="server" Text="ID" DataIndex="ID" Visible="False"></ext:Column>
							<ext:Column ID="ColumnHop" runat="server" Text="H" DataIndex="Hop" Width="50"></ext:Column>
							<ext:Column ID="ColumnTime" runat="server" Text="T" DataIndex="Time" Width="50"></ext:Column>
							<ext:Column ID="ColumnHost" runat="server" Text="Host" DataIndex="Host" Width="150"></ext:Column>
							<ext:Column ID="ColumnHostName" runat="server" Text="Host Name" DataIndex="HostName" Width="400"></ext:Column>
						</Columns>
					</ColumnModel>
					<SelectionModel>
						<ext:RowSelectionModel runat="server"/>
					</SelectionModel>
					<View>
						<ext:GridView runat="server" EnableTextSelection="true"/>
					</View>
				</ext:GridPanel>
			</Items>
		</diten:Panel>
	</Items>
</diten:Panel>
</Items>
</diten:Panel>
</Items>
<Content>

</Content>
</diten:Panel>