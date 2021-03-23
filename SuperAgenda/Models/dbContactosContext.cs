using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SuperAgenda.Models
{
    public partial class dbContactosContext : DbContext
    {
        public dbContactosContext()
        {
        }

        public dbContactosContext(DbContextOptions<dbContactosContext> options)
            : base(options)
        {
        }

		public DbSet<Contacts> Contactos { get; set; }



    }
}
