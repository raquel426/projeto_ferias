public class MeuComercio
/* o corpo de código terão comentários indicando qual propriedade do c# estará sendo usado, 
a fim de conferir se utilizei tudo ou esqueci de algo rs*/
{
    static List<ProdutosBase> listaProdutos = new() // usando listas
    {
        new ProdutosBase("Arroz", 22.90, 10),
        new ProdutosBase("Feijao", 13.45, 12),
        new ProdutosBase("Oleo", 11.00, 7),
        new ProdutosBase("Sal", 4.90, 5)
    };

    static void Main(string[] args)
    {
        bool continuarPrograma = true; // pesquisei uma forma de o programa voltar a rodar após escolher as opcoes

        while (continuarPrograma) // usando laçosss de repetição
        {
            Console.Clear();
            Console.WriteLine("Bᴇᴍ ᴠɪɴᴅᴏ(ᴀ) ᴀᴏ ꜱɪꜱᴛᴇᴍᴀ ᴅᴀ Qᴜɪᴛᴀɴᴅᴀ ᴅᴀ Vɪʟᴀ!");
            Thread.Sleep(1500);

            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("1 - Listar Produtos");
            Console.WriteLine("2 - Filtrar Produtos");
            Console.WriteLine("3 - Adicionar Produto");
            Console.WriteLine("4 - Remover Produto");
            Console.WriteLine("5 - Sair");

            int escolhaUsuario = ObterOpcao(); // criando métodos e usando o switch utilizando esses métodos no switch com enum

            switch (escolhaUsuario)
            {
                case (int)OpcoesIniciais.listar:
                    ListarProdutos(); // separei a nomenclatura dos métodos, e deixei a estrutura deles em 

                    break;

                case (int)OpcoesIniciais.filtrar:
                    FiltrarProdutos();
                    break;

                case (int)OpcoesIniciais.inserir:
                    AdicionarProduto();
                    break;

                case (int)OpcoesIniciais.apagar:
                    RemoverProduto();
                    break;

                case 5:
                    continuarPrograma = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Thread.Sleep(1500);
                    break;
            }
            SalvarEmTxt(); // metodo pra salvar um arquivo com os produtos listados quando o usuario selecionar a opcao de listar
            Console.WriteLine("\nLista de produtos atualizada e salva em seus documentos!");
            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
        // deixando a estrutura dos métodos no código principal
    static int ObterOpcao()
    {
        Console.Write("\nEscolha uma opção: ");
        if (int.TryParse(Console.ReadLine(), out int opcao))
            return opcao;

        Console.WriteLine("Por favor, digite um número válido.");
        return ObterOpcao();
    }

    static void ListarProdutos()
    {
        Console.Clear();
        Console.WriteLine("Produtos disponíveis na quitanda:\n");
        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"Nome: {produto.Nome}, Preço: R${produto.Preco:F2}, Quantidade: {produto.Quantidade}");
        } // :F2 pesquisei na internet pra deixar com duas casa decimais
        Console.WriteLine("\nPressione uma tecla para continuar...");
        Console.ReadKey();
    }

    static void FiltrarProdutos()
    {
        Console.Clear();
        Console.WriteLine("Por qual parâmetro deseja filtrar?");
        Console.WriteLine("1 - Nome");
        Console.WriteLine("2 - Preço");
        Console.WriteLine("3 - Quantidade");

        int parametro = ObterOpcao();

        switch (parametro) // usando o enum no swtich
        {
            case (int)Parametro.nome:
                Console.WriteLine("\nProdutos ordenados por Nome:");
                foreach (var produto in listaProdutos.OrderBy(p => p.Nome)) // usando linq e lambda
                {
                    Console.WriteLine($"Nome: {produto.Nome}, Preço: R${produto.Preco}, Quantidade: {produto.Quantidade}");
                }
                break;

            case (int)Parametro.preco:
                Console.WriteLine("\nProdutos ordenados por Preço:");
                foreach (var produto in listaProdutos.OrderBy(p => p.Preco))
                {
                    Console.WriteLine($"Nome: {produto.Nome}, Preço: R${produto.Preco}, Quantidade: {produto.Quantidade}");
                }
                break;

            case (int)Parametro.quantidade:
                Console.WriteLine("\nProdutos ordenados por Quantidade:");
                foreach (var produto in listaProdutos.OrderByDescending(p => p.Quantidade)) // neste caso, a quantidade é mostrada do maior para o menor
                {
                    Console.WriteLine($"Nome: {produto.Nome}, Preço: R${produto.Preco}, Quantidade: {produto.Quantidade}");
                }
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
        Console.WriteLine("\nPressione uma tecla para continuar...");
        Console.ReadKey();
    }

    static void AdicionarProduto()
    {
        Console.Clear();
        Console.WriteLine("Adicionar novo produto:");

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço do produto: ");
        double preco = double.Parse(Console.ReadLine());

        Console.Write("Digite a quantidade do produto: ");
        int quantidade = int.Parse(Console.ReadLine());

        listaProdutos.Add(new ProdutosBase(nome, preco, quantidade));
        Console.WriteLine("\nProduto adicionado com sucesso!");
        Thread.Sleep(1500);
    }

    static void RemoverProduto()
    {
        Console.Clear();
        Console.WriteLine("Remover produto:");

        Console.Write("Digite o nome do produto que deseja remover: ");
        string nome = Console.ReadLine();

        var produto = listaProdutos.FirstOrDefault(p => p.Nome.ToLower() == nome.ToLower());
        // usei o FirsOrDefault para treinar Linq em vez de usar o foreach, nao sei se podia mas deu certo rs

        if (produto != null)
        {
            listaProdutos.Remove(produto);
            Console.WriteLine("\nProduto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado.");
        }
        Thread.Sleep(1500);
    }
    static void SalvarEmTxt() // usando salvamento de arquivo + dicas de como escrever no arquivo
    {
        string caminhoArquivo = "ProdutosQuitanda.txt";

        using (StreamWriter documentoDeTexto = new StreamWriter(caminhoArquivo, false))
        {
            documentoDeTexto.WriteLine("Produtos Disponíveis:");
            documentoDeTexto.WriteLine("-------------------------------");
            foreach (var produto in listaProdutos)
            {
                documentoDeTexto.WriteLine($"Nome: {produto.Nome}, Preço: R${produto.Preco:F2}, Quantidade: {produto.Quantidade}");
            }
        } 
    }


    enum OpcoesIniciais // usando enum

    {
        listar = 1,
        filtrar,
        inserir,
        apagar
    }

    enum Parametro
    {
        nome = 1,
        preco,
        quantidade
    }
}

// o que faltou neste projetinho? 
// implementação de interfaces... não consegui encontrar uma forma de usa-las aqui
// uso de exceções, tentei usar um try catch mas ficou redundante devido ao "default" do switch