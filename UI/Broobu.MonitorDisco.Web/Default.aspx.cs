using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using Iris.MonitorDisco.Contract.Agent;
using Iris.MonitorDisco.Contract.Domain;

namespace Iris.MonitorDisco.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView.SettingsLoadingPanel.Enabled = true;
            GridView.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;

            if (Session["Services"] == null)
            {
                GetData();
                GridView.DataSource = Session["Services"];
                GridView.DataBind();
            }
            
            if (!IsPostBack)
            {
                GetData();
                if (Session["Services"] != null)
                {
                    GridView.DataSource = Session["Services"];
                    GridView.DataBind();
                }
                GroupColumns();
            }
            else
            {
                if (Session["Services"] != null)
                {
                    GridView.DataSource = Session["Services"];
                    GridView.DataBind();
                }
            }
        }

        private void GetData()
        {
            var agt = MonitorDiscoAgentFactory.CreateAgent();
            var items = agt.GetAllEndpoints();
            
            foreach (DiscoViewItem discoViewItem in items)
            {
                discoViewItem.Status = "Discovered";
            }
            if (Session["Services"] == null)
            {
                Session.Add("Services", items);
            }
            else
            {
                var oldItems = ((DiscoViewItem[])Session["Services"]).ToList();
                foreach (var discoViewItem in oldItems)
                {
                    discoViewItem.Status = "OffLine";
                }
                foreach (var discoViewItem in items)
                {
                    if (oldItems.Contains(discoViewItem))
                    {
                        var oldItem = oldItems.FirstOrDefault(i => i.Equals(discoViewItem));
                        if (oldItem != null)
                        {
                            oldItem.Status = "OnLine";
                        }
                        else
                        {
                            oldItems.Add(discoViewItem);
                        }
                    }
                    else
                    {
                        oldItems.Add(discoViewItem);
                    }
                }

                Session["Services"] = oldItems.ToArray();
            }

            
        }

        private void GroupColumns()
        {
            try
            {
                GridViewColumn layer = null;
                GridViewColumn application = null;
                foreach (GridViewDataColumn column in GridView.Columns)
                {
                    if (column.FieldName == "Layer")
                    {
                        layer = column;
                    }
                    else if (column.FieldName == "Application")
                    {
                        application = column;
                    }
                    else if (column.FieldName == "Host")
                    {
                        column.Width = 200;
                    }
                    else if (column.FieldName == "Service")
                    {
                        column.Width = 200;
                    }
                    else if (column.FieldName == "Contract")
                    {
                        column.Width = 200;
                    }
                }

                if (layer != null)
                {
                    GridView.GroupBy(layer);
                }
                if (application != null)
                {
                    GridView.GroupBy(application);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void GridView_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            
            if (e.RowType != GridViewRowType.Data) return;
            string status = (string)GridView.GetRowValues(e.VisibleIndex, "Status");
            switch (status)
            {
                case "Discovered":
                    for(int i = 0;i < e.Row.Cells.Count;i++)
                        e.Row.Cells[i].Style.Add("color", "Blue");
                    break;
                case "OnLine":
                    for(int i = 0;i < e.Row.Cells.Count;i++)
                        e.Row.Cells[i].Style.Add("color", "Green");
                    break;
                case "OffLine":
                    for(int i = 0;i < e.Row.Cells.Count;i++)
                        e.Row.Cells[i].Style.Add("color", "Red");
                    break;
            }

        }
    }
}
