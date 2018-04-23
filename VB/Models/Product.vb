Imports System
Imports System.Collections.Generic

Public Class Product
	Private Const DataItemsCount As Integer = 20

	Public Property Id() As Integer
	Public Property Text() As String
	Public Property Quantity() As Integer
	Public Property Price() As Decimal

	Public Shared Function GetData() As List(Of Product)
		Dim products As New List(Of Product)()

		Dim randomizer As New Random()

		For index As Integer = 0 To DataItemsCount - 1
			products.Add(New Product() With {.Id = index, .Text = "Text" & index.ToString(), .Quantity = randomizer.Next(1, 50), .Price = CDec(Math.Round((randomizer.NextDouble() * 100), 2))})
		Next index

		Return products
	End Function
End Class
