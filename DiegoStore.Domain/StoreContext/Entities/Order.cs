using System;
using System.Linq;
using System.Collections.Generic;
using DiegoStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace DiegoStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;

            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();

        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }

        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();

        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        // To Place An Order - Fechar Pedido, Gerar nota Fiscal Gerar entregas

        public void AddItem(Product product, decimal quantity)
        {
            // valida Item 
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");

            var item = new OrderItem(product, quantity);
            // Adiciona ao pedido 
            _items.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            // valida Item 
            // Adiciona ao pedido 
            _deliveries.Add(delivery);
        }

        // criar um pedido 
        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");
        }

        // pagar pedido 
        public void Pay()
        {

            Status = EOrderStatus.Paid;


        }
        // enviar pedido 
        public void Ship()
        {
            /// <summary>
            ///  A cada cinco produtor é uma entrega
            /// </summary>
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;
            }

            // _deliveries.Add(delivery);

            //Envia todas as entregas 
            deliveries.ForEach(x => x.Ship());

            // adiciona entregas ao pedido 
            deliveries.ForEach(x => _deliveries.Add(x));

        }
        // cancelar um pedido 
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

    }
}