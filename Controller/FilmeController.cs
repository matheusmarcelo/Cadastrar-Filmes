using System;
using Filmes.Modelo;

namespace Filmes.Controller
{
    public class FilmeController
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();

        public void ExcluirFilmes()
		{
			int escolha = 0;

			Console.WriteLine("Deseja mesmo excluir um filme?");
			Console.WriteLine("1- Sim       0- Não");
			escolha = int.Parse(Console.ReadLine());

			if(escolha == 1)
			{
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				repositorio.Exclui(indiceFilme);
			}
		}

        public void VisualizarFilmes()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

        public void AtualizarFilmes()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			Filmes obterFilme = ObterFilmes();

			repositorio.Atualiza(indiceFilme, obterFilme);
		}
        public void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhumo filme cadastrado.");
			}

			foreach (var filme in lista)
			{
                var excluido = filme.Excluido;
                
				Console.WriteLine("#ID {0}: - {1} {2} - Diretor: {3} - Atores: {4}", filme.retornaId(), filme.Titulo, (excluido ? "*Excluído*" : ""), filme.Diretor, filme.Atores);
			}
		}

        public void InserirFilmes()
		{
			Filmes obterFilme = ObterFilmes();
			Console.WriteLine("Inserir novo Filme");		

			repositorio.Insere(obterFilme);
		}

        public void listarPorGenero()
        {
            var lista = repositorio.Lista();

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

            var nomeGenero = Enum.GetName(typeof(Genero), entradaGenero);
            
            Console.WriteLine();

            foreach (var item in lista)
            {

                var genero = item.retornaGenero();

                var toGenero = Convert.ToString(genero);

				var excluido = item.Excluido;

                if(nomeGenero == toGenero)
                {
                    Console.WriteLine("Filme: {0} {1} - Genero: {2}", item.Titulo, (excluido ? "*Excluído*" : ""), toGenero);
                }
            }
        }

        public string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Hollywood Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Filmes");
			Console.WriteLine("2- Inserir novo Filmes");
			Console.WriteLine("3- Atualizar Filmes");
			Console.WriteLine("4- Excluir Filmes");
			Console.WriteLine("5- Visualizar Filmes");
            Console.WriteLine("6- Listar por genero");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

        public Filmes ObterFilmes()
		{

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de estreia do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o Diretor do Filme: ");
			string entradaDiretor = Console.ReadLine();

            Console.Write("Digite os atores do Filme: ");
			string entradaAtores = Console.ReadLine();

			Filmes novoFilme = new Filmes(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
                                        diretor: entradaDiretor,
                                        atores: entradaAtores);

			return novoFilme;
		}
    }
}