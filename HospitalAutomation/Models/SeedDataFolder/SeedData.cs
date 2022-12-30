using Hospital.Core.Enums;
using Hospital.DataAccess.EntityFramework.Context;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HospitalAutomation.Models.SeedDataFolder
{
    public static class SeedData
    {
        //Program.cs dosyasında bulunan app ile aynı şey
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HospitalDBContext>();
            dbContext.Database.Migrate();

            if (dbContext.Admins.Count() == 0)
            {
                dbContext.Admins.Add(new Admin()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Halil Can",
                    LastName = "Toptas",
                    EmailAddress = "halilcantoptas@gmail.com",
                    Status = Status.Active,
                    Password = "1234",
                    CreatedDate = DateTime.Now,
                });
            }
            dbContext.SaveChanges();
        }
    }
}
