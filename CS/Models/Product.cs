using System;
using System.Collections.Generic;

public class Product {
    const int DataItemsCount = 20;

    public int Id { get; set; }
    public string Text { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public static List<Product> GetData() {
        List<Product> products = new List<Product>();

        Random randomizer = new Random();

        for (int index = 0; index < DataItemsCount; index++) {
            products.Add(new Product() {
                Id = index,
                Text = "Text" + index.ToString(),
                Quantity = randomizer.Next(1, 50),
                Price = (decimal)Math.Round((randomizer.NextDouble() * 100), 2)
            });
        }

        return products;
    }
}
