using Microsoft.EntityFrameworkCore;
using PRJ_MVC_CORE_ORACLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ_MVC_CORE_ORACLE.Repositories
{
    public interface ISecaoRepository
    {
        IList<Secao> GetSecoes();
    }

    public class SecaoRepository : ISecaoRepository
    {
        protected readonly Contexto contexto;
        protected readonly DbSet<Secao> dbset;

        public SecaoRepository(Contexto contexto)
        {
            this.contexto = contexto;
            dbset = contexto.Set<Secao>();
        }

        public IList<Secao> GetSecoes()
        {
            return dbset.ToList();
        }
    }
}
