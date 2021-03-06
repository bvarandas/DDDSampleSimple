using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDSample.Domain.Models
{
    [Table("tb_AnuncioWebmotors")]
    public class Adv : Entity
    {
        public Adv(string marca, string modelo , string versao, int ano, int quilometragem, string observacao)
        {
            //ID = id;
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        public Adv(int id, string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            ID = id;
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        // Entity framework
        protected Adv() { }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Marca { get; private set; }

        public string Modelo { get; private set; }

        public string Versao { get; private set; }

        public int Ano { get; private set; }

        public int Quilometragem { get; private set; }

        public string Observacao { get; private set; }
    }
}
