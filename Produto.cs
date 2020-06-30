using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula27 {
    public class Produto {
        public Produto (int codigo, string nome, float preco) {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;

        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public Produto () {
        string pasta = PATH.Split ('/') [0];
        if(!Directory.Exists (pasta)) {
            Directory.CreateDirectory (pasta);
        }
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }
        private const string PATH = "Database/produto.csv";

        /// <summary>
        /// Cadastra um produto
        /// </summary>
        /// <param name="prod">Objeto</param>
        public void Cadastrar (Produto prod) {
            var linha = new string[] {
                PrepararLinha (prod)
            };
            File.AppendAllLines (PATH, linha);
        }

        /// <summary>
        /// Lê o csv
        /// </summary>
        /// <returns>Lista</returns>
        public List<Produto> Ler(){
            List<Produto> produtos = new List<Produto>();
            //tentativa de fazer o desafio:

            var Ler = from p in produtos where Preco > Codigo select produtos;

            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){
                string[] dado = linha.Split(";");

                Produto p = new Produto();
                p.Codigo = Int32.Parse(dado[0]);
                p.Nome = dado[1];
                p.Preco = float.Parse(dado[2]);
                produtos.Add(p);
            }

            return produtos;
        }
        private string Separar(string _coluna){
            return _coluna.Split("=")[1];
        }
        
        private string PrepararLinha (Produto p) {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}