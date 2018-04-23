using System;
using System.Collections.Generic;

public class Invoice {
    const int DataItemsCount = 20;
    
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime RegisterDate { get; set; }

    public static List<Invoice> GetData() {
        List<Invoice> invoices = new List<Invoice>();

        for (int i = 0; i < DataItemsCount; i++) {
            invoices.Add(new Invoice() {
                Id = i,
                Description = "Invoice" + i.ToString(),
                Price = i * 10,
                RegisterDate = DateTime.Today.AddDays(i - DataItemsCount)
            });
        }

        return invoices;
    }
}