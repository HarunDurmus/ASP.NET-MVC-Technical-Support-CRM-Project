using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikDestek.DataAccessLayer.EntityFramework;
using TeknikDestek.Entities;

namespace TeknikDestek.DataAccessLayer.EntityFramework
{
    public class MyInitializer :  CreateDatabaseIfNotExists<DataBaseContext>
    {/*
        protected override void Seed(DataBaseContext context)
        {
            // Adding admin user..
            Supporter admin = new Supporter()
            {
                firstName = "harun",
                lastName = "durmuş",
                userStatus = "admin",
                userName = "harun",
                password = "123"
   
            };

            // Adding standart user..
            Supporter supporterUser = new Supporter()
            {
                firstName = "ali",
                lastName = "baba",
                userStatus = "sp",
                userName = "muratbaseren",
                password = "123"
            };

            Supporter responsibleUser = new Supporter()
            {
                firstName = "veli",
                lastName = "kardeş",
                userStatus = "admin",
                userName = "rs",
                password = "123"
            };


            context.Supporters.Add(admin);
            context.Supporters.Add(supporterUser);
            context.Supporters.Add(responsibleUser);

            context.SaveChanges();
        }*/
    }
}
