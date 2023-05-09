using System;

string loginInput;
string senhaInput;
int find = -1;
string escolha;
int last = 0;

int loop2 = 0;

Empregado empregado1 = new Empregado("rafa", "123", new DateTime(2004, 04, 28), "123", true);
Empregado[] vetorEmpregados = new Empregado[1000];
vetorEmpregados[1] = new Empregado("Pedro", "000", new DateTime(2004, 05, 12), "000", false);
vetorEmpregados[0] = empregado1;
Ponto[] vetorPontos = new Ponto[1000];

while (loop2 == 0)
{

    int loop = 0;
    int loop1 = 0;


    while (loop == 0)
    {
        find = -1;

        Console.WriteLine("+-+-+-+-+-+  Sistema de Login  +-+-+-+-+--+");

        System.Console.WriteLine();
        Console.WriteLine("Digite o Login: ");
        loginInput = Console.ReadLine();
        Console.WriteLine("Digite o senha: ");
        senhaInput = Console.ReadLine();
        System.Console.WriteLine();
        Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");

        for (int i = 0; i < 1000; i++) //localiza index cpf
        {
            if (vetorEmpregados[i] != null)
            {
                if (vetorEmpregados[i].Cpf == loginInput && vetorEmpregados[i].Senha == senhaInput)
                {
                    find = i;
                    loop = 1;
                    break;
                }
            }
        }

        if (find == -1)
        {
            Console.WriteLine("CPF ou senha inválidos");
        }
    }

    while (loop1 == 0)
    {

        if (vetorEmpregados[find].IsAdmin == true)
        {
            System.Console.WriteLine();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine($"              Bom dia, {vetorEmpregados[find].Nome}");
            Console.WriteLine("+               Opções:                   +");
            Console.WriteLine("+                                         +");
            Console.WriteLine("+    1 - Cadastrar Novo Empregado         +");
            Console.WriteLine("+    2 - Listar Empregados                +");
            Console.WriteLine("+    3 - Mostrar olhas Trabalhadas        +");
            Console.WriteLine("+    4 - Sair                             +");
            Console.WriteLine("+                                         +");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine();
            Console.WriteLine("Digite uma das opções: ");
            escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Console.WriteLine("Digite o nome:");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o cpf:");
                string cpf = Console.ReadLine();
                Console.WriteLine("Digite o dia do nascimento:");
                string dia = Console.ReadLine();
                Console.WriteLine("Digite o mes do nascimento:");
                string mes = Console.ReadLine();
                Console.WriteLine("Digite o ano do nascimento:");
                string ano = Console.ReadLine();
                Console.WriteLine("Digite a senha:");
                string senha = Console.ReadLine();
                Console.WriteLine("Usúario é adm [true/false]: ");
                string adm = Console.ReadLine();


                for (int i = 0; i < 1000; i++) //localiza index cpf
                {
                    if (vetorEmpregados[i] == null)
                    {
                        last = i;
                        break;
                    }
                }
                vetorEmpregados[last] = new Empregado(nome, cpf, new DateTime(int.Parse(ano), int.Parse(mes), int.Parse(dia)), senha, bool.Parse(adm));
            }
            else if (escolha == "2")
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Mostrnado empregados: ");
                System.Console.WriteLine();
                for (int i = 0; i < 1000; i++) //localiza index cpf
                {
                    if (vetorEmpregados[i] == null)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"{i + 1}° Funcionário: {vetorEmpregados[i].Nome}");
                    }
                }
            }

            else if (escolha == "3")
            {
                if (escolha == "3")
                {
                    Console.WriteLine("Digite o CPF do empregado:");
                    string cpf = Console.ReadLine();
                    Console.WriteLine("Digite o mês:");
                    int mes = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o ano:");
                    int ano = int.Parse(Console.ReadLine());

                    int horasTrabalhadas = 0;
                    
                    int index = -1;
                    for (int i = 0; i < 1000; i++)
                    {
                        if (vetorPontos[i] != null && vetorPontos[i].Cpf == cpf)
                        {
                            index = i;
                            if (vetorPontos[i].DataHora.Month == mes && vetorPontos[i].DataHora.Year == ano)
                            {
                                if (vetorPontos[i].Tipo == TipoPonto.Entrada)
                                {
                                    horasTrabalhadas -= 1;
                                }
                                else
                                {
                                    horasTrabalhadas += 1;
                                }
                            }
                            Console.WriteLine($"{vetorEmpregados[index+1].Nome} trabalhou {horasTrabalhadas} horas no mês {mes}/{ano}.");
                        }
                        
                    }
                
                    
                }

            }
            else if (escolha == "4")
            {
                loop1 = 1;
                System.Console.WriteLine();
            }
        }

        if (vetorEmpregados[find].IsAdmin == false)
        {
            System.Console.WriteLine();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine($"              Bom dia, {vetorEmpregados[find].Nome}");
            Console.WriteLine("+               Opções:                   +");
            Console.WriteLine("+                                         +");
            Console.WriteLine("+    1 - Bater Ponto                      +");
            Console.WriteLine("+    2 - Sair                             +");
            Console.WriteLine("+                                         +");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine();
            Console.WriteLine("Digite uma das opções: ");
            escolha = Console.ReadLine();

            if (escolha == "1")
            {

                string cpfFuncionario = vetorEmpregados[find].Cpf;

                // Localiza o funcionário pelo CPF
                Empregado funcionario = null;
                for (int i = 0; i < 1000; i++)
                {
                    if (vetorEmpregados[i] != null && vetorEmpregados[i].Cpf == cpfFuncionario)
                    {
                        funcionario = vetorEmpregados[i];
                        break;
                    }
                }

                if (funcionario != null)
                {

                    bool jaBateuPonto = false;
                    for (int i = 0; i < 1000; i++)
                    {
                        if (vetorPontos[i] != null && vetorPontos[i].Funcionario == funcionario && vetorPontos[i].DataHoraEntrada.Date == DateTime.Now.Date)
                        {
                            jaBateuPonto = true;
                            vetorPontos[i].DataHoraSaida = DateTime.Now;
                            Console.WriteLine($"Saída registrada para {funcionario.Nome} às {DateTime.Now}");
                            break;
                        }
                    }

                    if (!jaBateuPonto)
                    {
                        // Registra entrada
                        for (int i = 0; i < 1000; i++)
                        {
                            if (vetorPontos[i] == null)
                            {
                                vetorPontos[i] = new Ponto(funcionario, DateTime.Now);
                                Console.WriteLine($"Entrada registrada para {funcionario.Nome} às {DateTime.Now}");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }

            }

            else if (escolha == "2")
            {
                loop1 = 1;
            }

        }
    }

}




public class Empregado
{
    private string nome;
    private string cpf;
    private DateTime dataNascimento;
    private string senha;
    private bool adm;

    public Empregado(string nome, string cpf, DateTime dataNascimento, string senha, bool adm)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.dataNascimento = dataNascimento;
        this.senha = senha;
        this.adm = adm;
    }

    public string Nome
    {
        get { return nome; }
    }

    public string Cpf
    {
        get { return cpf; }
    }

    public DateTime DataNascimento
    {
        get { return dataNascimento; }
    }

    public string Senha
    {
        get { return senha; }
    }

    public bool IsAdmin
    {
        get { return adm; }
    }
}


public enum TipoPonto
{
    Entrada,
    Saida
}

public class Ponto
{
    private Empregado funcionario;
    private DateTime dataHoraEntrada;
    private DateTime dataHoraSaida;

    public Ponto(Empregado funcionario, DateTime dataHoraEntrada)
    {
        this.funcionario = funcionario;
        this.dataHoraEntrada = dataHoraEntrada;
    }

    public Empregado Funcionario
    {
        get { return funcionario; }
    }

    public DateTime DataHoraEntrada
    {
        get { return dataHoraEntrada; }
    }

    public DateTime DataHoraSaida
    {
        get { return dataHoraSaida; }
        set { dataHoraSaida = value; }
    }

    public string Cpf
    {
        get { return funcionario.Cpf; }
    }

    public DateTime DataHora
    {
        get { return dataHoraEntrada; }
    }

    public TipoPonto Tipo
    {
        get { return TipoPonto.Entrada; }
    }
}
