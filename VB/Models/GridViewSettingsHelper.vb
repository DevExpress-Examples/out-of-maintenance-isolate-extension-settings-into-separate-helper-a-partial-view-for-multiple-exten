Imports System.Web.Mvc
Imports System.Web.UI
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.Mvc.UI

Public Module GridViewSettingsHelper
	<System.Runtime.CompilerServices.Extension> _
	Public Function CreateGridViewSettings(ByVal view As WebViewPage, ByVal gridType As GridType) As GridViewSettings
		Dim settings As New GridViewSettings()
		settings.Name = "GridView" & gridType.ToString()
		settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial", Key .gridType = gridType}
		settings.KeyFieldName = "Id"

		If gridType = GridType.Invoices Then
			settings.Columns.Add("Id")
			settings.Columns.Add("Price")
			settings.Columns.Add(Sub(column)
				column.Caption = "Description"
				column.SetDataItemTemplateContent(Sub(container)
					view.Html.DevExpress().HyperLink(Sub(hyperlink)
						Dim keyValue = container.KeyValue
						Dim description = DataBinder.Eval(container.DataItem, "Description")
						hyperlink.Name = "hl" & keyValue.ToString()
						hyperlink.Properties.Text = description.ToString()
						hyperlink.NavigateUrl = view.Url.Action("Details", "Home", New With {Key .key = keyValue})
					End Sub).Render()
				End Sub)
			End Sub)
		End If

		Return settings
	End Function
End Module