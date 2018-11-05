using System.Collections.Generic;
using FluentValidator;

namespace DiegoStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
            {
                AddNotification("Quantidade", "Produto fora de estoque!");
            }
        }
        public Product Product { get; set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        public IDictionary<string, string> Notifications { get; set; }

    }
}