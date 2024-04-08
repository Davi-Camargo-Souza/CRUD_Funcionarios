using CRUD_Funcionarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Funcionarios.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create (T entity, CancellationToken cancellationToken);
        void Inativar (Guid id, string tabela, CancellationToken cancellationToken);
        void Ativar (Guid id, string tabela, CancellationToken cancellationToken);
        Task<T> Get (Guid id, string tabela, CancellationToken cancellationToken);
        Task<List<T>> GetAll (string tabela, CancellationToken cancellationToken);
        Task<List<T>> GetAllAtivos (string tabela, CancellationToken cancellationToken);
        Task<List<T>> GetAllInativos (string tabela, CancellationToken cancellationToken);
        void Update (T entity);
        void Delete (T entity);

    }
}
