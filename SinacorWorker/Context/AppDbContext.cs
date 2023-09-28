using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SinacorWorker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinacorWorker.Context
{
    internal class AppDbContext: DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            var connectionString = "Server=localhost;Database=sinacor;Uid=root;Pwd=1234;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
