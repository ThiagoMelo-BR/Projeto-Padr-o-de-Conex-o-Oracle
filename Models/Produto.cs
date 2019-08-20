using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PRJ_MVC_CORE_ORACLE.Models
{
    [DataContract]
    public class Produto
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public virtual Departamento Departamento { get; set; }
        [DataMember]
        public string Embalagem { get; set; }
        [DataMember]
        [ForeignKey("CODEPTO")]        
        public int DepartamentoId { get; set; }
        [DataMember]
        public virtual Secao Secao { get; set; }
        [DataMember]
        [ForeignKey("CODSEC")]
        public int SecaoId { get; set; }
        [DataMember]
        public Fornecedor Fornecedor { get; set; }
        [ForeignKey("CODFORNEC")]
        [DataMember]
        public int FornecedorId { get; set; }


    }
}
