<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Desktop.aspx.cs" Inherits="Diten.Web.UI.Pages.Desktop" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<title>DITeN - Desktop</title>
	<script>
		var tile = function() {
			Ext.net.Desktop.desktop.tileWindows();
		};

		var cascade = function() {
			Ext.net.Desktop.desktop.cascadeWindows();
		};

		var initSlidePanel = function() {
			this.setHeight(Ext.net.Desktop.desktop.body.getHeight());

			if (!this.windowListen) {
				this.windowListen = true;
				this.show();
				this.el.alignTo(Ext.net.Desktop.desktop.body, 'tl-tr', [0, 0]);

				Ext.on("resize", initSlidePanel, this);
			}
		};

		Ext.onReady(function() {
			App.direct.Initialize();
			App.direct.Initialize();
		});
	</script>
</head>
<body>
<form id="FormMain" runat="server">
	<diten:ResourceManager ID="DitenResourceManager" runat="server" AjaxViewStateMode="Enabled" AjaxTimeout="120000" FormID="FormMain">
		<Listeners>
			<WindowResize Handler="Ext.net.Bus.publish('App.Desktop.ready');" Buffer="500"/>
		</Listeners>
	</diten:ResourceManager>
	<diten:Desktop ID="DesktopControl" runat="server">
		<Modules>
			<ext:DesktopModule ModuleID="tmp_Module">
				<Shortcut Name=" " X="1200" Y="1100" TextCls="x-long-label">
				</Shortcut>
			</ext:DesktopModule>
		</Modules>
		<DesktopConfig Wallpaper="~/resources/wallpapers/blue.jpg" ShortcutDragSelector="true">
			<ShortcutDefaults IconCls="x-default-shortcut"/>
			<ContextMenu>
				<ext:Menu runat="server">
					<Items>
						<ext:MenuItem runat="server" Text="Change Settings"/>
						<ext:MenuSeparator runat="server"/>
						<ext:MenuItem runat="server" Text="Tile" Handler="tile" Icon="ApplicationTileVertical"/>
						<ext:MenuItem runat="server" Text="Cascade" Handler="cascade" Icon="ApplicationCascade"/>
					</Items>
				</ext:Menu>
			</ContextMenu>
			<Content>
				<ext:Image runat="server" ImageUrl="~/resources/logo.png" StyleSpec="position:absolute;top: 50%;left: 50%;width: 77px; height: 78px;margin-top: -39px; margin-left: -39px;"/>
				<ext:Image runat="server" ImageUrl="~/resources/powered.png" StyleSpec="position:absolute;right:10px;bottom:20px;width:300px;height:39px;"/>
			</Content>
		</DesktopConfig>
		<StartMenu Title="Ext.Net Desktop" Icon="Application" Height="300">
			<ToolConfig>
				<ext:Toolbar runat="server" Width="100">
					<Items>
						<ext:Button runat="server" Text="Settings" Icon="Cog"/>
						<ext:Button runat="server" Text="Logout" Icon="Key">
							<DirectEvents>
								<Click OnEvent="Logout_Click">
									<EventMask ShowMask="true" Msg="Good Bye..." MinDelay="1000"/>
								</Click>
							</DirectEvents>
						</ext:Button>
					</Items>
				</ext:Toolbar>
			</ToolConfig>
		</StartMenu>
		<TaskBar QuickStartWidth="80" TrayWidth="125">
			<QuickStart>
				<ext:Toolbar runat="server">
					<Items>
						<ext:Button runat="server" Handler="tile" Icon="ApplicationTileVertical" OverflowText="Test windows">
							<QTipCfg Text="Test windows"/>
							<DirectEvents>
								<Click OnEvent="Logout_Click"></Click>
							</DirectEvents>
						</ext:Button>
						<ext:Button runat="server" Handler="cascade" Icon="ApplicationCascade" OverflowText="Cascade windows">
							<QTipCfg Text="Cascade windows"/>
						</ext:Button>
					</Items>
				</ext:Toolbar>
			</QuickStart>
			<Tray>
				<ext:Toolbar runat="server">
					<Items>
						<diten:Button ID="LangButton" runat="server" Text="EN" Cls="x-bold-text" MenuAlign="br-tr" ArrowVisible="false">
							<Menu>
								<ext:Menu runat="server">
									<Items>
										<ext:CheckMenuItem runat="server" Group="lang" Text="English" Checked="true" CheckHandler="function (item, checked) {checked && #{LangButton}.setText('EN');}"/>
										<ext:CheckMenuItem runat="server" Group="lang" Text="French" CheckHandler="function (item, checked) {checked && #{LangButton}.setText('FR');}"/>
										<ext:MenuSeparator runat="server"/>
										<ext:MenuItem runat="server" Text="Show the Language Bar"/>
									</Items>
								</ext:Menu>
							</Menu>
						</diten:Button>
						<ext:ToolbarFill runat="server"/>
					</Items>
				</ext:Toolbar>
			</Tray>
		</TaskBar>
		<Listeners>
			<Ready BroadcastOnBus="App.Desktop.ready"/>
		</Listeners>
	</diten:Desktop>
</form>
</body>
</html>