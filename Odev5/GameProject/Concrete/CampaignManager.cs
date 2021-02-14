using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameProject.Abstract
{
    public class CampaignManager : ICampaignService
    {
        public void Add(Campaign campaign)
        {
            Console.WriteLine("Add Campaign");
        }

        public void Delete(Campaign campaign)
        {
            Console.WriteLine("Delete Campaign");
        }

        public Campaign Get(Expression<Func<Campaign, bool>> filter)
        {
            Console.WriteLine("Get Campaign");

            return new Campaign();
        }

        public List<Campaign> GetAll(Expression<Func<Campaign, bool>> filter = null)
        {
            Console.WriteLine("Get Campaigns");

            return new List<Campaign>();
        }

        public void Update(Campaign campaign)
        {
            Console.WriteLine("Update Campaign");
        }
    }
}
