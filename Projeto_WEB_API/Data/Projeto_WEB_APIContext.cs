using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_WEB_API.Models;

namespace Projeto_WEB_API.Data
{
    public class Projeto_WEB_APIContext : DbContext
    {
        public Projeto_WEB_APIContext (DbContextOptions<Projeto_WEB_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; } = default!;
    }
}
