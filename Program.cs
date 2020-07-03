using System;
using System.Collections.Generic;

namespace Aula27
{
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 4;
            p1.Nome = "Playstation 5";
            p1.Preco = 3499f;

            p1.Cadastrar(p1);
            p1.Remover("xbox X");


            Produto alterado = new Produto();
            alterado.Codigo = 2;
            alterado.Nome = "Pc";
            alterado.Preco = 6000f;

            p1.Alterar(alterado);




            List<Produto> lista = p1.Ler();

            foreach(Produto item in lista){
                System.Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }

        }
    }
}
