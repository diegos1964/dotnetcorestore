using DiegoStore.Domain.StoreContext.Entities;
using DiegoStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiegoStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Diego", "Monte");
            var document = new Document("12345678911");
            var email = new Email("diego@teste.com.br");
            var c = new Customer(name, document, email, "61985423265");

            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("Cadeira", "Cadeira", "image.png", 559.90M, 10);

            var order = new Order(c);

            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(impressora, 5));
            order.AddItem(new OrderItem(cadeira, 5));

            order.Place();

            var valid = order.IsValid;
            order.Pay();
            order.Ship();
            order.Cancel();
        }
    }
}
