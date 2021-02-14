using GameProject.Abstract;
using GameProject.Adapters;
using GameProject.Concrete;
using GameProject.Entities;
using System;
using System.Collections.Generic;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ICampaignService campaignService = new CampaignManager();
            ICustomerService customerService = new CustomerManager(new MernisServiceAdapter());
            IOrderItemService orderItemService = new OrderItemManager();
            IOrderService orderService = new OrderManager(orderItemService);
            IProductService productService = new ProductManager();


            Customer customer = new Customer()
            {
                Id = 1,
                TcNumber = "27595144254",
                FirstName = "Gökçenur",
                LastName = "Zenginal",
                DateOfBirth = new DateTime(1993, 8, 23)
            };

            Customer customer2 = new Customer()
            {
                Id = 2,
                TcNumber = "12345978912",
                FirstName = "test2",
                LastName = "test2",
                DateOfBirth = new DateTime(1993, 1, 23)
            };

            Product product = new Product()
            {
                Id = 1,
                Nane = "Product 1",
                Price = 15
            };

            Campaign campaign = new Campaign()
            {
                Id = 1,
                Nane = "Campaign 1",
                Discount = 50
            };

            Campaign campaign2 = new Campaign()
            {
                Id = 1,
                Nane = "Campaign 2",
                Discount = 15
            };

            Console.WriteLine("****************Oyuncu ekleme****************");
            customerService.Add(customer);
            Console.WriteLine();

            Console.WriteLine("****************Oyuncu güncelleme****************");
            customer.FirstName = "test3";
            customerService.Update(customer);
            Console.WriteLine();

            Console.WriteLine("****************Oyuncu silme****************");
            customerService.Delete(customer2);
            Console.WriteLine();

            Console.WriteLine("****************Oyun satışı****************");
            orderService.Add(customer, product,2);
            Console.WriteLine();

            Console.WriteLine("****************Kampanya ekleme****************");
            campaignService.Add(campaign);
            Console.WriteLine();

            Console.WriteLine("****************Kampanya güncelleme****************");
            campaign.Discount = 25;
            campaignService.Update(campaign);
            Console.WriteLine();

            Console.WriteLine("****************Kampanya silme****************");
            campaignService.Delete(campaign2);
            Console.WriteLine();

            Console.WriteLine("****************Kampanyalı Oyun satışı****************");
            orderService.Add(customer, product,2, campaign);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
