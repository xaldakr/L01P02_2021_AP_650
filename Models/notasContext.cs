using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01P02_2021_AP_650.Models{
    public class notasContext:DbContext{
        public notasContext(DbContextOptions<notasContext> options) : base (options){

        }
        public DbSet<depart> departamentos {get; set;}
        public DbSet<mater> materias {get; set;}
        public DbSet<facultade> facultades {get; set;}
        public DbSet<alumn> alumnos  {get; set;}
    }
}