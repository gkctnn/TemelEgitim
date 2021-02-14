using GameProject.Abstract;
using GameProject.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Adapters
{
    public class MernisServiceAdapter : ICustomerCheckService
    {
        public bool CheckIfRealCustomer(Customer customer)
        {
            try
            {
                KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

                var response = client.TCKimlikNoDogrulaAsync(new TCKimlikNoDogrulaRequest(new TCKimlikNoDogrulaRequestBody(Convert.ToInt64(customer.TcNumber), customer.FirstName.ToUpper(), customer.LastName.ToUpper(), customer.DateOfBirth.Year)));

                if (response != null && response?.Result?.Body?.TCKimlikNoDogrulaResult == true)
                {
                    Console.WriteLine("Real Customer");

                    return true;
                }
                else
                {
                    Console.WriteLine("Fake Customer");

                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fake Customer");

                return false;
            }



        }
    }
}
