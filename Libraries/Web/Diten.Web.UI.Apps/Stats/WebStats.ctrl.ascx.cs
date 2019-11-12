#region Using Directives

using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Diten.Net;
using Ext.Net;
using Microsoft.Web.Administration;
using Panel = Diten.Web.UI.WebControls.Panel;
using ProgressBar = Diten.Web.UI.WebControls.ProgressBar;
using ServerManager = Diten.Web.Administration.ServerManager;

#endregion

namespace Diten.Web.UI.Apps.Stats
{
	// ReSharper disable once InconsistentNaming
	public partial class WebStats : UserControl
	{
		private const string ViewStateVisitors = "ViewStateVisitors";

		private DateTime SelectedStartDate { get; set; }
		private DateTime SelectedEndDate { get; set; }

		public string SiteName { get; set; }

		public new Site Site => ServerManager.Sites[SiteName];

		private DataTable VisitorIps
		{
			get
			{
				if (ViewState[ViewStateVisitors] != null &&
				    !((DataTable) ViewState[ViewStateVisitors]).Rows.Count.Equals(0))
					return (DataTable) ViewState[ViewStateVisitors];
				//todo: Ado
				//ViewState[ViewStateVisitors] = Data.Ado.Helpers.Stats.GetVisitorIps(StartDate, EndDate, Site.Id);

				return (DataTable) ViewState[ViewStateVisitors];
			}
			set => ViewState[ViewStateVisitors] = value;
		}

		private DateTime StartDate => PDateFieldStartDate.SelectedDate;
		private DateTime EndDate => PDateFieldEndDate.SelectedDate;

		/// <summary>
		///     Page on load event handler.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event args.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			InitializeComponents();

			if (X.IsAjaxRequest) return;

			PDateFieldStartDate.SelectedDate = DateTime.Now;
			PDateFieldEndDate.SelectedDate = PDateFieldStartDate.SelectedDate;
		}

		/// <summary>
		///     Initialize components.
		/// </summary>
		private void InitializeComponents()
		{
			ProgressBar.Update += ProgressBar_Update;
			ProgressBar.Maximum = 30;
		}

		private void ProgressBar_Update(object sender, ProgressBar.UpdateEventArgs e)
		{
			//todo: Ado
			//GridPanelTracert.GetStore().DataSource = TracertListDataTable;
			GridPanelTracert.GetStore().DataBind();
		}

		protected void PDateFieldStartDate_OnSelect(object sender, DirectEventArgs e)
		{
			if (PDateFieldEndDate.SelectedDate < PDateFieldStartDate.SelectedDate)
			{
				X.Msg.Alert("Warning", "End date must be grater or equal to start date.").Show();
				return;
			}

			if (SelectedStartDate.Equals(StartDate)) return;

			VisitorIps.Rows.Clear();
			VisitorIps = null;
			DataBind();
		}

		protected void PDateFieldEndDate_OnSelect(object sender, DirectEventArgs e)
		{
			if (PDateFieldStartDate.SelectedDate > PDateFieldEndDate.SelectedDate)
			{
				X.Msg.Alert("Warning", "Start date must be smaller or equal to end date.").Show();
				return;
			}

			if (SelectedEndDate.Equals(EndDate)) return;

			VisitorIps.Rows.Clear();
			VisitorIps = null;
			DataBind();
		}

		private new void DataBind()
		{
			SelectedStartDate = StartDate;
			SelectedEndDate = EndDate;

			SetCartesianChart(CartesianChart0_10, 0, 10);
			SetCartesianChart(CartesianChart10_100, 10, 100);
			SetCartesianChart(CartesianChart100_500, 100, 500);
			SetCartesianChart(CartesianChart500_1000, 500, 1000);
			SetCartesianChart(CartesianChart1000_5000, 1000, 5000);
			SetCartesianChart(CartesianChart5000_25000, 5000, 25000);
			SetCartesianChart(CartesianChart25000_100000, 25000, 100000);
			SetCartesianChart(CartesianChart100000_Infinity, 100000, int.MaxValue);
			//todo: Ado
			//CartesianChartVCByDate.GetStore().DataSource =
			//    Data.Ado.Helpers.Stats.GetPeriodStats(StartDate, EndDate, Site.Id);
			CartesianChartVCByDate.GetStore().DataBind();

			TabPanelCharts.SetActiveTab(0);
			TabPanel0_1000.SetActiveTab(0);
			TabPanel1000_Infinity.SetActiveTab(0);

			if (VisitorIps.Rows.Count.Equals(0))
			{
				X.Msg.Alert("Information", $@"There is no log-info between [{StartDate}] and [{EndDate}].");
				return;
			}

			var hostName = "Indistinguishable";

			try
			{
				TextFieldTotalVisitCount.Text = VisitorIps.Rows.Count.ToString();
				TextFieldMostVisitorIp.Text = VisitorIps.Rows[0]["ClientIp"].ToString();
				TextFieldMostVisitorIpVisitCount.Text = VisitorIps.Rows[0]["VisitCount"].ToString();
				if (IPAddress.TryParse(VisitorIps.Rows[0]["ClientIp"].ToString(), out var ipAddress))
				{
					hostName = Net.Dns.GetHostName(ipAddress);
					HyperlinkMostVisitorWebAddress.NavigateUrl = $@"JavaScript:window.open('http://{hostName}');";
				}
			}
			catch (SocketException)
			{
				hostName = "Indistinguishable";
			}

			HyperlinkMostVisitorWebAddress.Text = $@"[{hostName}]";

			if (VisitorIps.Rows.Count.Equals(0)) return;
			ComboBoxIps.Disabled = false;
			ComboBoxIps.GetStore().DataSource = VisitorIps;
			ComboBoxIps.GetStore().DataBind();
		}

		private void SetCartesianChart(AbstractChart cartesianChart, int minimum, int maximum)
		{
			var parentPanel = (Panel) cartesianChart.Parent;
			var dataSource = new DataTable();

			try
			{
				//ToDo: Remarked for Error.
				//dataSource = VisitorIps.Select($@"VisitCount >= {minimum} AND VisitCount <= {maximum}")
				//    .CopyToDataTable();
				parentPanel.Disabled = false;
			}
			catch (InvalidOperationException)
			{
				parentPanel.Disabled = true;
			}
			finally
			{
				cartesianChart.GetStore().DataSource = dataSource;
				cartesianChart.GetStore().DataBind();
			}
		}

		#region Traceroute procidures

		private Tracert _tracert;

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="directEventArgs"></param>
		protected void ComboBoxIps_OnSelect(object sender, DirectEventArgs directEventArgs)
		{
			//todo: Ado
			//var tracertListRow = TracertListDataTable.NewTracertListRow();
			var hostName = @"Indistinguishable";
			var selectedItem = ((ComboBox) sender).SelectedItem;

			//todo: Ado
			//tracertListRow["Id"] = Guid.NewGuid();
			TextFieldSelectedIpVisitCount.Text = selectedItem.Value;

			try
			{
				if (IPAddress.TryParse(selectedItem.Text, out var ipAddress))
					if (string.IsNullOrEmpty(selectedItem.Text) || string.IsNullOrWhiteSpace(selectedItem.Text))
						HyperlinkSelectedIpWebAddress.Disabled = true;
					else
						try
						{
							hostName = Net.Dns.GetHostName(ipAddress);
							HyperlinkSelectedIpWebAddress.NavigateUrl =
								$@"JavaScript:window.open('http://{hostName}');";
							HyperlinkSelectedIpWebAddress.Disabled = false;
						}
						catch (Exception)
						{
							// ignored
						}
			}
			catch (SocketException)
			{
				HyperlinkSelectedIpWebAddress.Disabled = true;
			}

			HyperlinkSelectedIpWebAddress.Text = $@"[{hostName}]";
			ButtonTrace.Disabled = false;
		}

		private void HopAction(object state)
		{
			while (!TraceIsDone)
			{
				if (!HopIsDone) continue;

				//todo: Ado
				//ProgressBar.Value = TracertListDataTable.Rows.Count;
				HopIsDone = false;
			}
		}

		protected void ButtonTrace_Click(object sender, DirectEventArgs directEventArgs)
		{
			if (string.IsNullOrEmpty(ComboBoxIps.SelectedItem.Text))
			{
				X.Msg.Alert("Warning", "Please select an IP address.").Show();
				return;
			}

			if (!IPAddress.TryParse(ComboBoxIps.SelectedItem.Text, out var ipAddress)) return;

			//todo: Ado
			//TracertListDataTable.Rows.Clear();
			var thread = new Thread(TraceRouteThread);
			thread.Start();

			ThreadPool.QueueUserWorkItem(HopAction);
			ProgressBar.Value = 0;
			ProgressBar.Start();
		}

		private void TraceRouteThread()
		{
			_tracert = new Tracert(ComboBoxIps.SelectedItem.Text);
			_tracert.OnDone += Tracert_OnDone;
			_tracert.OnRouteNodeFound += Tracert_OnRouteNodeFound;
			_tracert.Trace();
		}

		private bool TraceIsDone { get; set; }

		private bool HopIsDone { get; set; }

		private void Tracert_OnDone(object sender, EventArgs e)
		{
			_tracert.Dispose();
			TraceIsDone = true;
		}

		private void Tracert_OnRouteNodeFound(object sender, RouteNodeFoundEventArgs e)
		{
			//todo: Ado
			//var tracertListRow = TracertListDataTable.NewTracertListRow();
			//tracertListRow["Id"] = Guid.NewGuid();
			//tracertListRow["Hop"] = TracertListDataTable.Rows.Count + 1;
			//tracertListRow["Time"] = e.Node.Status == IPStatus.Success ? e.Node.RoundTripTime.ToString() : 0.ToString();
			//tracertListRow["Host"] = e.Node.Address.ToString();

			//if (e.Node.Status == IPStatus.Success)
			//    System.Net.Dns.BeginGetHostEntry(e.Node.Address, OnGetHostEntry, tracertListRow);

			//TracertListDataTable.Rows.Add(tracertListRow);
			//TracertListDataTable.AcceptChanges();
			HopIsDone = true;
		}

		private const string ViewStateTracertList = "ViewStateTracertList";

		//todo: Ado
		//private Data.Ado.Tracert.TracertListDataTable TracertListDataTable
		//{
		//    get
		//    {
		//        if (Session[ViewStateTracertList] == null)
		//            Session[ViewStateTracertList] = new Data.Ado.Tracert.TracertListDataTable();

		//        return (Data.Ado.Tracert.TracertListDataTable) Session[ViewStateTracertList];
		//    }
		//}

		private static void OnGetHostEntry(IAsyncResult ar)
		{
			try
			{
				//todo: Ado
				//var tracertListRow = ar.AsyncState as Data.Ado.Tracert.TracertListRow;
				//if (tracertListRow != null)
				//    tracertListRow["HostName"] = System.Net.Dns.EndGetHostEntry(ar).HostName;
				//else
				//    throw new ArgumentNullException();
			}
			catch (SocketException)
			{
			}
		}

		#endregion
	}
}