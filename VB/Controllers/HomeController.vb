Imports System.Web.Mvc

Namespace GridViewSharePartialHelper.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function GridViewPartial(ByVal gridType As GridType) As ActionResult
			Dim model As Object = Nothing

			If gridType = GridType.Invoices Then
				model = Invoice.GetData()
			ElseIf gridType = GridType.Products Then
				model = Product.GetData()
			End If

			ViewData("gridType") = gridType

			Return PartialView(model)
		End Function

		Public Function Details(ByVal key As Integer) As ActionResult
			Return View(key)
		End Function
	End Class
End Namespace