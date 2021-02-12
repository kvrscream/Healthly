using System;
using System.Collections.Generic;
using System.Text;
using Heathly.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heathly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<PersonModel> Clientes { get; set; }

        public DbSet<PlainModel> Planos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
