using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PRJ_MVC_CORE_ORACLE.Models;
using System.Linq;


namespace PRJ_MVC_CORE_ORACLE.Repositories
{
    public interface IDeparmentoRepository
    {
        IList<Departamento> GetDepartamentos();
    }

    public class DepartamentoRepository : IDeparmentoRepository
    {
        protected readonly Contexto contexto;
        protected readonly DbSet<Departamento> dbset;

        public DepartamentoRepository(Contexto contexto)
        {
            this.contexto = contexto;
            dbset = contexto.Set<Departamento>();
        }

        public IList<Departamento> GetDepartamentos()
        {
            return dbset.ToList();

        }
    }
}
