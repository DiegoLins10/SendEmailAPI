using Microsoft.EntityFrameworkCore;
using SendEmailAPI.Entities;
using System.Collections.Generic;


namespace SendEmailAPI.Persistence
{
    public class EmailContext : DbContext
    {

        public EmailContext(DbContextOptions<EmailContext> options) : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageUpdate> PackageUpdates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>(d =>
           {
               //d.ToTable("tb_Package");
               d.HasKey(p => p.Id);

               // um pacote tem muitos updates relacionado com uma chave estrangeira do pacote
               d.HasMany(p => p.Updates)
               .WithOne()
               .HasForeignKey(pu => pu.PackageId)
               .OnDelete(DeleteBehavior.Restrict); //impede de deletar
           });

            builder.Entity<PackageUpdate>(d =>
            {
                d.HasKey(p => p.Id);
            });
        }
    }
}
