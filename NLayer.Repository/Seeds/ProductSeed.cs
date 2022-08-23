using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasData(new Product
            {
                Id=1,
                CategoryId=1,
                Name="Kalem 1",
                Price=100,
                Stock=20,
                CreatedDate=DateTime.Now

            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Price = 120,
                Name="Kalem 2",
                Stock = 30,
                CreatedDate = DateTime.Now

            }
            ,
            new Product
            {
                Id = 3,
                CategoryId = 1,
                Price = 150,
                Name = "Kalem 3",
                Stock = 40,
                CreatedDate = DateTime.Now

            },
            new Product
            {
                Id = 4,
                CategoryId = 2,
                Price = 100,
                Name = "Kitap 1 ",
                Stock = 70,
                CreatedDate = DateTime.Now

            },
            new Product
            {
                Id = 5,
                CategoryId = 2,
                Price = 80,
                Name = "Kitap 2 ",
                Stock = 60,
                CreatedDate = DateTime.Now

            });





        }
    }
}
