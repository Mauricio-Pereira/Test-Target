using Newtonsoft.Json;
using Test_Target;



// Exercicio 1

string Exercicio1()
{
    int indice = 13;
    int soma = 0;
    int k = 0;

    while (k < indice)
    {
        k++;
        soma += k;
    }

    return $"O valor da soma é {soma}";
}

// Exercicio 2 - metodo auxiliar
static bool PertenceFibonacci(int n)
{
    if (n < 0) return false;

    int a = 0, b = 1;
    while (a <= n)
    {
        if (a == n) return true;
        int temp = a;
        a = b;
        b = temp + b;
    }
    return false;
}


// Exercicio 2

string Exercicio2()
{
    Console.WriteLine("Digite um número inteiro:");
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
        bool pertence = PertenceFibonacci(numero);
        return pertence ? "Pertence à sequência de Fibonacci" : "Não pertence à sequência de Fibonacci";
    }
    else
    {
        return "Número inválido";
    }
}


// Exercicio 3 - metodo auxiliar para carregar faturamento
static List<Faturamento> CarregarFaturamento()
{
    string caminhoArquivo = "../ex4.json";
    if (!File.Exists(caminhoArquivo))
    {
        Console.WriteLine("Arquivo de faturamento não encontrado.");
        return new List<Faturamento>();
    }

    string json = File.ReadAllText(caminhoArquivo);
    try
    {
        return JsonConvert.DeserializeObject<List<Faturamento>>(json) ?? new List<Faturamento>();
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Erro ao ler o arquivo JSON: {ex.Message}");
        return new List<Faturamento>();
    }
}

void Exercicio3()
{
    var faturamentos = CarregarFaturamento();

    var faturamentosValidos = faturamentos.Where(f => f.Valor > 0).ToList();

    if (!faturamentosValidos.Any())
    {
        Console.WriteLine("Nenhum faturamento válido encontrado.");
        return;
    }

    double menorFaturamento = faturamentosValidos.Min(f => f.Valor);
    double maiorFaturamento = faturamentosValidos.Max(f => f.Valor);
    double mediaMensal = faturamentosValidos.Average(f => f.Valor);

    int diasAcimaMedia = faturamentosValidos.Count(f => f.Valor > mediaMensal);

    Console.WriteLine($"Menor faturamento: R${menorFaturamento}");
    Console.WriteLine($"Maior faturamento: R${maiorFaturamento}");
    Console.WriteLine($"Média mensal: R${mediaMensal}");
    Console.WriteLine($"Dias com faturamento acima da média:{diasAcimaMedia}");
}



// Exercicio 4
void Exercicio4()
{
    var faturamentoPorEstado = new (string Estado, double Valor)[]
    {
        ("SP", 67836.43),
        ("RJ", 36678.66),
        ("MG", 29229.88),
        ("ES", 27165.48),
        ("Outros", 19849.53)
    };

    // Calcula o faturamento total
    double faturamentoTotal = 0;
    foreach (var (_, valor) in faturamentoPorEstado)
    {
        faturamentoTotal += valor;
    }

    // Exibe os percentuais de representação por estado
    Console.WriteLine("Percentual de Representação por Estado:");
    foreach (var (estado, valor) in faturamentoPorEstado)
    {
        double percentual = (valor / faturamentoTotal) * 100;
        Console.WriteLine($"{estado}: {percentual:F2}%");
    }
}

// Exercicio 5 - inverter caracteres de uma string

string Exercicio5(string texto)
{
    Stack<char> pilha = new Stack<char>();
    foreach (char c in texto)
    {
        pilha.Push(c);
    }
    
    String invertido = "";
    while (pilha.Count > 0)
    {
        invertido += pilha.Pop();
    }
    
    return invertido;
    
}

Console.WriteLine("Executando Exercício 1:");
Console.WriteLine(Exercicio1());

Console.WriteLine("\nExecutando Exercício 2:");
Console.WriteLine(Exercicio2());

Console.WriteLine("\nExecutando Exercício 3:");
Exercicio3();

Console.WriteLine("\nExecutando Exercício 4:");
Exercicio4();

Console.WriteLine("\nExecutando Exercício 5:");
Console.WriteLine(Exercicio5("Teste de inversão de string"));