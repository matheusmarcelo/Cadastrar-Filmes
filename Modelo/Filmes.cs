using System;
using System.Collections.Generic;
using Filmes.Modelo;

namespace Filmes
{
    public class Filmes : EntidadeBase
    {
        private Genero Genero { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public int Ano { get; set; }
        public bool Excluido {get; set;}
        public string Diretor { get; set; }
        public string Atores { get; set; }
    
        public Filmes(int id, Genero genero, string titulo, string descricao, int ano, string diretor, string atores)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
            this.Diretor = diretor;
            this.Atores = atores;
	    }

        public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            retorno += "Diretor: " + this.Diretor + Environment.NewLine;
            retorno += "Atores: " + this.Atores;
			return retorno;
		}
		public int retornaId()
		{
			return this.Id;
		}
        public void Excluir() {
            this.Excluido = true;
        }

        public Genero retornaGenero()
        {
            return this.Genero;
        }
    }
}