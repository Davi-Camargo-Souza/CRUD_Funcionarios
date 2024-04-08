using CRUD_Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Funcionarios.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<FuncionarioEntity> Funcionarios { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    }
}
