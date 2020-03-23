using DDD.AplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infrastructure.Data
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configura nome da tabela no banco
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Address>().ToTable("Adresses");
            modelBuilder.Entity<Profession>().ToTable("Professions");
            modelBuilder.Entity<Client>().ToTable("ClientProfessions");

            #region Client DB Configs

            modelBuilder.Entity<Client>()
                .HasKey(e => e.Id);

            //informa associação de um cliente para vários contatos
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Contacts)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .HasPrincipalKey(e => e.Id);

            //define o tamanho do campo Cpf na base para varchar(11) e como obrigatório
            modelBuilder.Entity<Client>().Property( e => e.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();
            
            modelBuilder.Entity<Client>().Property( e => e.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();
            #endregion

            #region Contact DB Congigs
            modelBuilder.Entity<Contact>().HasOne(e => e.Client)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.ClientId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Contact>().Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Contact>().Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder.Entity<Contact>().Property(e => e.Phone)
                .HasColumnType("varchar(15)");
            #endregion

            #region Address DB Configs
            modelBuilder.Entity<Address>().Property(e => e.District)
                .HasColumnType("varchar(100)")
                .IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.Zipcode)
                .HasColumnType("varchar(15)")
                .IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.Street)
                .HasColumnType("varchar(200)")
                .IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.City)
                .HasColumnType("varchar(100)")
                .IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.Region)
                .HasColumnType("varchar(2)")
                .IsRequired();
            modelBuilder.Entity<Address>().Property(e => e.Country)
                .HasColumnType("varchar(50)")
                .IsRequired();
            #endregion
            //base.OnModelCreating(modelBuilder);

            #region Profession DB Configs
            modelBuilder.Entity<Profession>().Property(e => e.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
            modelBuilder.Entity<Profession>().Property(e => e.CBO)
                .HasColumnType("varchar(10)")
                .IsRequired();
            modelBuilder.Entity<Profession>().Property(e => e.Description)
                .HasColumnType("varchar(1000)")
                .IsRequired();
            #endregion

            #region ClientProfessions configurations
            modelBuilder.Entity<ClientProfession>().HasKey(e => e.Id);
            modelBuilder.Entity<ClientProfession>().HasOne(e => e.Client)
                .WithMany(e => e.ClientProfessions)
                .HasForeignKey(e => e.ClientId)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<ClientProfession>().HasOne(e => e.Profession)
                .WithMany(e => e.ClientProfessions)
                .HasForeignKey(e => e.ProfessionId)
                .HasPrincipalKey(e => e.Id);
            #endregion

            #region Menu DB Configs
            modelBuilder.Entity<Menu>().HasKey(e => e.Id);
            modelBuilder.Entity<Menu>()
                .HasMany(e => e.SubMenu)
                .WithOne()
                .HasForeignKey(e => e.MenuId);
            #endregion
        }
    }
}
