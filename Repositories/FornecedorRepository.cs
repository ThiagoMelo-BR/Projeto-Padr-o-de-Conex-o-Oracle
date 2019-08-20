using Microsoft.EntityFrameworkCore;
using PRJ_MVC_CORE_ORACLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ_MVC_CORE_ORACLE.Repositories
{
    public interface IFornecedorRepository
    {
        IList<Fornecedor> GetFornecedores();
    }
    public class FornecedorRepository : IFornecedorRepository
    {
        protected readonly Contexto contexto;
        protected readonly DbSet<Fornecedor> dbSet;

        public FornecedorRepository(Contexto contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<Fornecedor>();
        }

        public IList<Fornecedor> GetFornecedores()
        {
            return dbSet.ToList();
        }
    }
}
