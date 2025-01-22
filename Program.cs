using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.IO;

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
string desejaEspeciais = Console.ReadLine()??" ";
if(desejaEspeciais!="Sim" && desejaEspeciais!="Não")
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
string desejaABCD = Console.ReadLine()??" ";
if(desejaABCD!="Sim" && desejaABCD!="Não")
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
            int DecimalAleatorio = rand.Next(10);
            senha.Add(Decimal[DecimalAleatorio]);
        break;
        case 1:
            if(desejaABCD=="Sim")
            {
                int AbcdAleatorio = rand.Next(26);
                senha.Add(abcd[AbcdAleatorio]);
            }
            else {
                goto Return4;
            }
        break;
        case 2:
            if(desejaABCD=="Sim")
            {
                int ABCDAleatorio = rand.Next(26);
                senha.Add(ABCD[ABCDAleatorio]);
            }
            else {
                goto Return4;
            }
        break;
        case 3:
            if(desejaEspeciais=="Sim")
            {
                int EspecialAleatorio = rand.Next(26);
                senha.Add(especial[EspecialAleatorio]);
            }
            else {
                goto Return4;
            }
        break;
    }
}

Console.ForegroundColor = ConsoleColor.Green;
using (StreamWriter Salvar = new StreamWriter("Nova-Senha.txt"))
{
    Salvar.Write("Sua nova senha e: ");
    Console.Write("Sua nova senha e: ");

    for(int i = 0; i<NumDigitos; i++)
    {
        Salvar.Write(senha[i]);
        Console.Write(senha[i]);
    }
}
Console.ResetColor();
