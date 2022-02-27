using CampaignModule;
using CampaignModule.Commands;
using CampaignModule.Factories;
using CampaignModule.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCampaignModule
{
    [TestClass]
    public class UnitTest1
    {
        static ProductRepository productRepo = ProductRepositoryFactory.GetInstance();
        static CampaignRepository campaignRepo = CampaignRepositoryFactory.GetInstance();
        static OrderRepository orderRepo = OrderRepositoryFactory.GetInstance();
        static DateTime dateTimeProperty = new DateTime(0);

        [TestMethod]
        public void CreateProduct()
        {
            ProductCreateCommand command = new ProductCreateCommand("P1", 100, 1000);

            Product product = new Product(command.ProductCode, command.Price, command.Stock);
          
            productRepo.Create(product);
        }

        [TestMethod]
        public void GetProductInfo()
        {
            productRepo.GetInfo("P1");
        }

        [TestMethod]
        public void CreateOrder()
        {
            OrderCreateCommand command = new OrderCreateCommand("P1",3);

            Order order = new Order(command.ProductCode, command.Quantity);

            orderRepo.Create(order);
        }

        [TestMethod]
        public void GetOrder()
        {
            orderRepo.GetInfo("P1");
        }

        [TestMethod]
        public void CreateCampaign()
        {
            CampaignCreateCommand command = new CampaignCreateCommand("C1", "P1", 10, 20, 100);

            Campaign campaign = new Campaign(command.Name, command.ProductCode, command.Duration, command.PriceManipulationLimit, command.TargetSalesCount);

            campaignRepo.Create(campaign);
        }

        [TestMethod]
        public void GetCampaignInfo()
        {
            campaignRepo.GetInfo("C1");
        }

        [TestMethod]
        public void IncreaseTime()
        {
            dateTimeProperty = dateTimeProperty.AddHours(1);

            string endHour = dateTimeProperty.ToString("hh:mm");
            Console.WriteLine($"Time is {endHour}");
        }
    }
}
