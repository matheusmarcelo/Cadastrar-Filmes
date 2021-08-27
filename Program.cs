using System;
using System.Collections.Generic;
using System.Linq;
using Filmes.Controller;
using Filmes.Modelo;

namespace Filmes
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
		static FilmeController filmeController = new FilmeController();
        static void Main(string[] args)
        {
            string obterUsuario = filmeController.ObterOpcaoUsuario();

            while(obterUsuario.ToUpper() != "X")
            {
                switch (obterUsuario)
                {
                    case "1":
						filmeController.ListarFilmes();
						break;
					case "2":
						filmeController.InserirFilmes();
						break;
					case "3":
						filmeController.AtualizarFilmes();
						break;
					case "4":
						filmeController.ExcluirFilmes();
						break;
					case "5":
						filmeController.VisualizarFilmes();
						break;
                    case "6":
                        filmeController.listarPorGenero();
                        break;  
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
                }
                obterUsuario = filmeController.ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }      

    }
}
