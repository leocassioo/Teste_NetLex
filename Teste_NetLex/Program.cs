using System;
using System.Collections.Generic;
using System.Linq;

namespace Teste_NetLex
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string texto = "Aqui é Body Builder Ipsum PORRA!" +
				"Sai de casa comi pra caralho porra. " +
				"Aqui nóis constrói fibra, não é água com músculo. " +
				"Eita porra!, tá saindo da jaula o monstro!Vamo monstro!" +
				"Tá comigo porra. Boraaa, Hora do Show Porra.";

			Console.Write("Quantas linhas deseja?: ");
			int numero = Convert.ToInt32(Console.ReadLine());

			Console.Clear();

			var vetorTexto = texto.Split(' ').ToList();
			List<string> lista = new List<string>();

			bool processado = false;

			while (!processado)
			{
				if (vetorTexto.Count > numero)
				{
					for (int i = 0; i < vetorTexto.Count; i++)
					{

						if (i + 1 < vetorTexto.Count)
						{
							lista.Add(string.Format("{0} {1}", vetorTexto[i], vetorTexto[i + 1]));
							vetorTexto.RemoveAt(i + 1);
						}
						else if (i == vetorTexto.Count - 1)
							lista.Add(vetorTexto[i]);

						if (vetorTexto.Count < numero && lista.Count < numero)
						{
							for (int j = lista.Count; j < vetorTexto.Count; j++)
							{
								lista.Add(vetorTexto[j]);
							}


							string ultimaPalavra = lista.Last().Split(' ').Last();

							lista[lista.Count - 1] = lista.Last().Replace(lista.Last().Split(' ').Last(), string.Empty);
							lista.Add(ultimaPalavra);
							processado = true;

							break;
						}
					}
				}

				if (lista.Count == numero)
					processado = true;
				else if (lista.Count > numero)
				{
					vetorTexto = new List<string>();

					foreach (var item in lista)
					{
						vetorTexto.Add(item);
					}

					lista = new List<string>();
				}
			}

			foreach (var item in lista)
			{
				Console.WriteLine(item);
			}

			Console.ReadKey();
		}
	}
}