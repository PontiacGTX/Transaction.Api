
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Transactions.Data.Entities;

namespace Transactions.Data
{
    public class AppDbContext:IdentityDbContext<Cliente>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        {

        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<CuentasClientes> CuentasClientes { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
        public DbSet<TipoCuenta> TiposDeCuentas { get; set; }
        public DbSet<TipoSolicitudMovimiento> TipoSolicitudMovimientos { get; set; }
        public DbSet<TipoMovimientos> TipoDeMovimientos { get; set; }
        public DbSet<PropiedadCuenta> PropiedadCuentas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            builder.Entity<Cliente>().Property(x => x.Id).HasColumnName("ClienteId");
            builder.Entity<Cliente>().Property(x => x.PasswordHash).HasColumnName("Contraseña");
            builder.Entity<Cliente>().HasOne(x => x.Persona).WithOne(x => x.Cliente);
            //builder.Entity<Persona>().HasOne<Genero>().WithMany(x => x.Personas)
            //    .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Cliente>().HasOne(x => x.Persona).WithOne(x => x.Cliente);
            builder.Entity<Genero>().HasData(new Genero[] { new Genero { GeneroId = 1, Nombre = "Femenino" }, new Genero { GeneroId =2,Nombre= "Maculino" } });




            builder.Entity<CuentasClientes>().HasKey(x => x.CuentasClientesId);
            
            builder.Entity<CuentasClientes>().HasOne(x => x.Cliente).WithMany(x => x.CuentasClientes);
            builder.Entity<PropiedadCuenta>().HasData(new PropiedadCuenta[] { new PropiedadCuenta { PropiedadCuentaId = 1, Nombre = "Abonable" }, new PropiedadCuenta { PropiedadCuentaId = 2, Nombre = "Crediticia" } });
            builder.Entity<TipoCuenta>().HasData(new TipoCuenta[] { new TipoCuenta { TipoCuentaId = 1, Nombre = "Ahorro"  , Habilitado = true, PropiedadCuentaId = 1 }, new TipoCuenta { TipoCuentaId =2,Nombre= "Corriente", Habilitado= true, PropiedadCuentaId = 1 } });
            builder.Entity<TipoSolicitudMovimiento>().HasData(new TipoSolicitudMovimiento[] { new TipoSolicitudMovimiento { TipoSolicitudMovimientoId = 1, Nombre = "Abono"  }, new TipoSolicitudMovimiento { TipoSolicitudMovimientoId = 2,Nombre= "Debito" } });
            builder.Entity<TipoMovimientos>().HasData(new TipoMovimientos[] { new TipoMovimientos { TipoMovimientoId = 1, TipoMovimiento = "Abono" , Habilitado=true }, new TipoMovimientos { TipoMovimientoId = 2, TipoMovimiento= "Debito", Habilitado =true } });

            base.OnModelCreating(builder);
            builder.Entity<CuentasClientes>().Ignore(x => x.Id);
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<Cliente>().ToTable("Clientes");
        }
    }
}