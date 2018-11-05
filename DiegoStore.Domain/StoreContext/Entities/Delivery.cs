using System;
using DiegoStore.Domain.StoreContext.Enums;

namespace DiegoStore.Domain.StoreContext.Entities
{

    public class Delivery
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Wainting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //  Se a data estimada de entrega for no passado não entregar.
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            // se o status já estiver como entregue não é possivel cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}