public class ProdutosBase : MeuComercio
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

    public ProdutosBase(string nome, double preco, int quantidade) // metodo construtor
    {
        Nome = nome; // relacionando atributos aos parametros do metodo construtor
        Preco = preco;
        Quantidade = quantidade;

    }
    public void ExibirInformacao()
    {
        Console.WriteLine($"Estas sao as informacoes do produto: Nome:{Nome} Preço:{Preco} Quantidade:{Quantidade}");
    } 
}