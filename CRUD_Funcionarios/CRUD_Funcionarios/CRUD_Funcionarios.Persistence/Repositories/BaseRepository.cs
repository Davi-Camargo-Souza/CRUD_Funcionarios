using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Interfaces;
using CRUD_Funcionarios.Persistence.Context;
using CRUD_Funcionarios.Domain.Exceptions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CRUD_Funcionarios.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DapperContext _dapper;

        public BaseRepository(AppDbContext context, DapperContext dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async void Create (T entity, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entity, cancellationToken);
        }

        public async void Inativar (Guid id, string tabela, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"{tabela}\" " +
                             $"WHERE \"Id\" = '{id}'";
                var entity = await connection.QueryFirstOrDefaultAsync<T>(sql, cancellationToken);
                connection.Close();
                if (entity == null) throw new RegistroNaoEncontradoException();
                entity.Ativo = false;
                Update(entity);
            }
        }

        public async void Ativar(Guid id, string tabela, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"{tabela}\" " +
                             $"WHERE \"Id\" = '{id}'";
                var entity = await connection.QueryFirstOrDefaultAsync<T>(sql, cancellationToken);
                connection.Close();
                if (entity == null) throw new RegistroNaoEncontradoException();
                entity.Ativo = true;
                Update(entity);
            }
        }

        public async Task<T> Get (Guid id, string tabela, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"{tabela}\" " +
                             $"WHERE \"Id\" = '{id}'";
                var entity = await connection.QueryFirstOrDefaultAsync<T>(sql, cancellationToken);
                connection.Close();
                if (entity == null) throw new RegistroNaoEncontradoException();
                return entity;
            }
        }

        public async Task<List<T>> GetAll (string tabela, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"{tabela}\"";
                var entity = await connection.QueryAsync<T>(sql, cancellationToken);
                connection.Close();
                if (entity == null) return null;
                return entity.ToList();
            }
        }

        public async Task<List<T>> GetAllAtivos(string tabela, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"{tabela}\" " +
                             $"WHERE \"Ativo\" = '1'";
                var entity = await connection.QueryAsync<T>(sql, cancellationToken);
                connection.Close();
                if (entity == null) return null;
                return entity.ToList();
            }
        }

        public async Task<List<T>> GetAllInativos(string tabela, CancellationToken cancellationToken)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * " +
                             $"FROM \"{tabela}\" " +
                             $"WHERE \"Ativo\" = '0'";
                var entity = await connection.QueryAsync<T>(sql, cancellationToken);
                connection.Close();
                if (entity == null) return null;
                return entity.ToList();
            }
        }

        public void Update (T entity)
        {
            _context.Update(entity);
        }

        public  void Delete(T entity)
        {
            _context.Remove(entity);
        }
    }
}
