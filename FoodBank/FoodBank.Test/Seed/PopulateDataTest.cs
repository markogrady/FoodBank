using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Seed;
using Xunit;

namespace FoodBank.Test.Seed
{
    public class PopulateSeedDataTest
    {
        [Fact]
        public async void PopulateData()
        {
            using (var context = new AppDbContext())
            {
                SeedAll.SeedAllData(context);
               
            }

        }
    }
}
