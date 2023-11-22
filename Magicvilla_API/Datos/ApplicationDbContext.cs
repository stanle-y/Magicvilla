using Magicvilla_API.modelos;
using Microsoft.EntityFrameworkCore;

namespace Magicvilla_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {

            
        }
        public DbSet<Villa> Villas { get; set; }


        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            modeBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalles de la villa...",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad="",
                    FechaCreacion=DateTime.Now,
                    FechaActualizacion=DateTime.Now,


                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Premium vista al mar rojo",
                    Detalle = "Detalles de la villa...",
                    ImagenUrl = "",
                    Ocupantes = 20,
                    MetrosCuadrados = 200,
                    Tarifa = 1000,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,


                }
           );
           
         
            
        }

    }
}
