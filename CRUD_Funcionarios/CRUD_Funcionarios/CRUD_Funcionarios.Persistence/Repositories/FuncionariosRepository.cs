using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Enums;
using CRUD_Funcionarios.Domain.Interfaces;
using CRUD_Funcionarios.Persistence.Context;
using Dapper;

namespace CRUD_Funcionarios.Persistence.Repositories
{
    public class FuncionariosRepository : BaseRepository<FuncionarioEntity>, IFuncionariosRepository
    {
        private readonly AppDbContext _context;
        private readonly DapperContext _dapper;
        public FuncionariosRepository(AppDbContext context, DapperContext dapper) : base(context, dapper)
        {
            _dapper = dapper;
            _context = context;
        }

        public async Task<List<FuncionarioEntity>> GetAllFuncionarioByTurno(TurnoEnum turno, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                var inteiro = Convert.ToInt32(turno);
                string sql = $"SELECT * " +
                             $"FROM \"Funcionarios\" " +
                             $"WHERE \"Turno\" = '{inteiro}'";
                var result = await connection.QueryAsync<FuncionarioEntity>(sql, cancellationToken);
                connection.Close();
                if (result == null) return null;
                return result.ToList();
            }
        }

        public async Task<List<FuncionarioEntity>> GetAllFuncionarioByDepartamento(DepartamentoEnum departamento, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                var inteiro = Convert.ToInt32(departamento);
                string sql = $"SELECT * " +
                             $"FROM \"Funcionarios\" " +
                             $"WHERE \"Departamento\" = '{inteiro}'";
                var result = await connection.QueryAsync<FuncionarioEntity>(sql, cancellationToken);
                connection.Close();
                if (result == null) return null;
                return result.ToList();
            }
        }

        public async Task<FuncionarioEntity> GetFuncionarioByCPF(string cpf, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"Funcionarios\" " +
                             $"WHERE \"CPF\" = '{cpf}'";
                var result = await connection.QueryFirstOrDefaultAsync<FuncionarioEntity>(sql, cancellationToken);
                connection.Close();
                if (result == null) return null;
                return result;
            }
        }

        public async Task<FuncionarioEntity> GetFuncionarioByEmail(string email, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"Funcionarios\" " +
                             $"WHERE \"Email\" = '{email}'";
                var result = await connection.QueryFirstOrDefaultAsync<FuncionarioEntity>(sql, cancellationToken);
                connection.Close();
                if (result == null) return null;
                return result;
            }
        }
    }
}
