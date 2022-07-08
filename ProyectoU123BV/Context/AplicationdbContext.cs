using Microsoft.EntityFrameworkCore;
using ProyectoU123BV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoU123BV.Context
{
    public class AplicationdbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server = localhost; database= proyectou1; user= root; password= ");
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
