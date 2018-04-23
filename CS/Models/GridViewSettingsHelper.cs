using System.Web.Mvc;
using System.Web.UI;
using DevExpress.Web.Mvc;
using DevExpress.Web.Mvc.UI;

public static class GridViewSettingsHelper {
    public static GridViewSettings CreateGridViewSettings(this WebViewPage view, GridType gridType) {
        GridViewSettings settings = new GridViewSettings();
        settings.Name = "GridView" + gridType.ToString();
        settings.CallbackRouteValues = new { Controller = "Home", Action = "GridViewPartial", gridType = gridType };
        settings.KeyFieldName = "Id";

        if (gridType == GridType.Invoices) {
            settings.Columns.Add("Id");
            settings.Columns.Add("Price");
            settings.Columns.Add(column => {
                column.Caption = "Description";
                column.SetDataItemTemplateContent(container => {
                    view.Html.DevExpress().HyperLink(hyperlink => {
                        var keyValue = container.KeyValue;
                        var description = DataBinder.Eval(container.DataItem, "Description");

                        hyperlink.Name = "hl" + keyValue.ToString();
                        hyperlink.Properties.Text = description.ToString();
                        hyperlink.NavigateUrl = view.Url.Action("Details", "Home", new { key = keyValue });
                    }).Render();
                });
            });
        }

        return settings;
    }
}