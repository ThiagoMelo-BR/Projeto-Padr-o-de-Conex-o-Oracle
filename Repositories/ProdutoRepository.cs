using Microsoft.EntityFrameworkCore;
using PRJ_MVC_CORE_ORACLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRJ_MVC_CORE_ORACLE.Repositories
{
    public interface IProdutoRepository
    {
        IList<Produto> GetProdutos();
        void Excluir(Produto p);
        void Atualizar(Produto p);
        Produto GetProduto(int Codigo);
    }
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly Contexto contexto;
        protected readonly DbSet<Produto> dbSet;

        public ProdutoRepository(Contexto contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<Produto>(); 
        }

        public void Atualizar(Produto p)
        {
            if(p.Id <= 0)
            {
                p.Id = GetProxId();
                dbSet.Add(p);
            }
            else
            {
                dbSet.Update(p);
            }
            
            contexto.SaveChanges();
        }


        public int GetProxId()
        {
            var proxId = 0;
            using (var command = contexto.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select max(codprod) + 1 as codigo from PCPRODUT";
                contexto.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    result.Read();
                    proxId = Convert.ToInt32(result["codigo"].ToString());                    
                    result.Close();
                }
            }
            return proxId;
        }

        public void Excluir(Produto p)
        {
            dbSet.Remove(p);
            contexto.SaveChanges();
        }

        public Produto GetProduto(int Codigo)
        {
            return dbSet.ToList().Where(p => p.Id == Codigo).FirstOrDefault();
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet
                .Include(p => p.Departamento)
                .Include(s => s.Secao)
                .Include(f => f.Fornecedor)
                .OrderByDescending(p => p.Id)
                .ToList();            
        }
    }
}
