using System.IO;

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


        public void Cadastrar (Produto prod) {
            var linha = new string[] {
                PrepararLinha (prod)
            };
            File.AppendAllLines (PATH, linha);
        }

        private string PrepararLinha (Produto p) {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}