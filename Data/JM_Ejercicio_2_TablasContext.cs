using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JM_Ejercicio_2_Tablas.Models;

namespace JM_Ejercicio_2_Tablas.Data
{
    public class JM_Ejercicio_2_TablasContext : DbContext
    {
        public JM_Ejercicio_2_TablasContext (DbContextOptions<JM_Ejercicio_2_TablasContext> options)
            : base(options)
        {
        }

        public DbSet<JM_Ejercicio_2_Tablas.Models.Burger> Burger { get; set; } = default!;

        public DbSet<JM_Ejercicio_2_Tablas.Models.Promo>? Promo { get; set; }
    }
}
