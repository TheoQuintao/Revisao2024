using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.IO;
class Program
{
    static void Main()
    {
        string salvarSenha = " ";
        CriarSenha(ref salvarSenha);
    }
    public static void CriarSenha(ref string salvarSenha)
    {
        char[] Decimal = new char[10] {'1','2','3','4','5','6','7','8','9','0'};
        char[] ABCD = new char[26] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        char[] abcd = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        char[] especial = new char[26] {'?', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}','|', ';', ':', '/', '<', '>', '~'};

        Random rand = new Random();

        List<char> senha = new List<char>();


        Return1:
        Console.Clear();
        Console.Write("Deseja uma senha de quantos digitos? ");
        if(!int.TryParse(Console.ReadLine(), out int NumDigitos))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite apenas números!!!");
            Thread.Sleep(1500);
            Console.ResetColor();
            goto Return1;
        }

        Return2:
        Console.Clear();
        Console.Write("Deseja adicionar caracteres especiais a senha? (Sim) (Não) ");
        string desejaEspeciais = Console.ReadLine()?.ToLower()??" ";
        if(desejaEspeciais!="sim" && desejaEspeciais!="não")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite apenas Sim ou Não!!!");
            Thread.Sleep(1500);
            Console.ResetColor();
            goto Return2;

        }

        Return3:
        Console.Clear();
        Console.Write("Deseja adicionar letras a senha? (Sim) (Não) ");
        string desejaABCD = Console.ReadLine()?.ToLower()??" ";
        if(desejaABCD!="sim" && desejaABCD!="não")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite apenas Sim ou Não!!!");
            Thread.Sleep(1500);
            Console.ResetColor();
            goto Return3;
        }

        for(int i = 0; i<NumDigitos; i++)
        {   
            Return4:
            int numAleatorio = rand.Next(4);
            switch(numAleatorio)
            {
                case 0:
                    senha.Add(Decimal[rand.Next(10)]);
                break;
                case 1:
                    if(desejaABCD=="sim")
                    {
                        senha.Add(abcd[rand.Next(26)]);
                    }
                    else {
                        goto Return4;
                    }
                break;
                case 2:
                    if(desejaABCD=="sim")
                    {
                        senha.Add(ABCD[rand.Next(26)]);
                    }
                    else {
                        goto Return4;
                    }
                break;
                case 3:
                    if(desejaEspeciais=="sim")
                    {
                        senha.Add(especial[rand.Next(26)]);
                    }
                    else {
                        goto Return4;
                    }
                break;
            }
        }
        salvarSenha = new string(senha.ToArray());
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Sua nova senha e: {salvarSenha}");
        Console.ResetColor();
    }
    public static void SalvarSenhas(ref string salvarSenha)
    {
        List<string> Senhas = new List<string>{};
        Return1:
        Console.Clear();
        Console.Write("Adicione um rotulo para sua senha (Exemplo: Senha do bando): ");
        String Rotulo = Console.ReadLine()??" ";
        Return2:
        Console.Clear();
        Console.Write($"Deseja confirmar o rotulo: {Rotulo} (Sim) (Não) ");
        string confirmarRotulo = Console.ReadLine()?.ToLower()??" ";
        switch(confirmarRotulo)
        {
            case "sim":
                string senha = Rotulo + " - " + salvarSenha;
                Senhas.Add(senha);
                File.WriteAllLines("Senhas-Salvas.txt", Senhas);
            break;
            case "não":
            goto Return1;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escreva apenas Sim ou Não");
                Thread.Sleep(1000);
                Console.ResetColor();
            goto Return2;
        }
    }
}