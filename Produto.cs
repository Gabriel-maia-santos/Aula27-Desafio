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
        /// Lê o csv
        /// </summary>
        /// <returns>Lista</returns>
        public List<Produto> Ler(){
            List<Produto> produtos = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){
                string[] dado = linha.Split(";");

                Produto p = new Produto();
                p.Codigo = Int32.Parse(dado[0]);
                p.Nome = dado[1];
                p.Preco = float.Parse(dado[2]);
                produtos.Add(p);
            }
            produtos = produtos.OrderBy(y => y.Nome).ToList();
            return produtos;
        }
        public void Remover(string _termo){


            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(l => l.Contains(_termo));

            ReescreverCSV(linhas);
        }
        

        public void Alterar(Produto _produtoAlterado){

            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(z => z.Split(";")[0].Split("=")[1] == _produtoAlterado.Codigo.ToString());

            linhas.Add( PrepararLinha(_produtoAlterado) );

            ReescreverCSV(linhas);         
        }


        private void ReescreverCSV(List<string> lines){
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }

        public List<Produto> Filtrar(string _nome)
        {
            return Ler().FindAll(x => x.Nome == _nome);
        }

        private string Separar(string _coluna)
        {

            return _coluna.Split("=")[1];
        }
        
        private string PrepararLinha (Produto p) {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}