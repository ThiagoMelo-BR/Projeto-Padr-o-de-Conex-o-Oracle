using Microsoft.EntityFrameworkCore;
using PRJ_MVC_CORE_ORACLE.Models;

namespace PRJ_MVC_CORE_ORACLE.Repositories
{
    public class Contexto : DbContext
    {
        
        public Contexto(DbContextOptions options) : base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Departamento>().ToTable("PCDEPTO").Property(d => d.Id).HasColumnName("CODEPTO");
            modelBuilder.Entity<Departamento>().ToTable("PCDEPTO").Property(d => d.Descricao).HasColumnName("DESCRICAO");
                        
            modelBuilder.Entity<Produto>().ToTable("PCPRODUT").Property(p => p.DepartamentoId).HasColumnName("CODEPTO");            
            modelBuilder.Entity<Produto>().ToTable("PCPRODUT").Property(p => p.Id).HasColumnName("CODPROD");
            modelBuilder.Entity<Produto>().ToTable("PCPRODUT").Property(p => p.Descricao).HasColumnName("DESCRICAO");
            modelBuilder.Entity<Produto>().ToTable("PCPRODUT").Property(p => p.Embalagem).HasColumnName("EMBALAGEM");
            modelBuilder.Entity<Produto>().ToTable("PCPRODUT").Property(p => p.SecaoId).HasColumnName("CODSEC");
            modelBuilder.Entity<Produto>().ToTable("PCPRODUT").Property(p => p.FornecedorId).HasColumnName("CODFORNEC");

            modelBuilder.Entity<Secao>().ToTable("PCSECAO").Property(s => s.Id).HasColumnName("CODSEC");
            modelBuilder.Entity<Secao>().ToTable("PCSECAO").Property(s => s.Descricao).HasColumnName("DESCRICAO");

            modelBuilder.Entity<Fornecedor>().ToTable("PCFORNEC").Property(f => f.Id).HasColumnName("CODFORNEC");
            modelBuilder.Entity<Fornecedor>().ToTable("PCFORNEC").Property(f => f.Descricao).HasColumnName("FORNECEDOR");

            /*
            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(p => p.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(p => p.Pedido).IsRequired();
            */
        }
    }
}
