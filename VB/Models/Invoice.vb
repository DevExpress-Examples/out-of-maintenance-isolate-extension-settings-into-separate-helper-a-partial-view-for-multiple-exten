Imports System
Imports System.Collections.Generic

Public Class Invoice
	Private Const DataItemsCount As Integer = 20

	Public Property Id() As Integer
	Public Property Description() As String
	Public Property Price() As Decimal
	Public Property RegisterDate() As Date

	Public Shared Function GetData() As List(Of Invoice)
		Dim invoices As New List(Of Invoice)()

		For i As Integer = 0 To DataItemsCount - 1
			invoices.Add(New Invoice() With {.Id = i, .Description = "Invoice" & i.ToString(), .Price = i * 10, .RegisterDate = Date.Today.AddDays(i - DataItemsCount)})
		Next i

		Return invoices
	End Function
End Class