using Microsoft.EntityFrameworkCore;
using PucMinas.ControleCursos.WebAPI.Models.Entities;

namespace PucMinas.ControleCursos.WebAPI.Repositories.Context
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aluno>().HasKey(m => m.Cpf);
            base.OnModelCreating(builder);
        }
        
        public DbSet<Aluno> Aluno { get; set; }
    }
}
