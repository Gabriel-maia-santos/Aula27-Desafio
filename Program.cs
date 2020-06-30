using System;

namespace Aula27
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Playstation 5";
            p1.Preco = 4500f;

            p1.Cadastrar(p1);

        }
    }
}
