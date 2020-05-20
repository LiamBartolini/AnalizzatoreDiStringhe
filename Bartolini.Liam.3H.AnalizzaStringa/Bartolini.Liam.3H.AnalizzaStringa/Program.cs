using System;

namespace Bartolini.Liam._3H.AnalizzaStringa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Analizzatore stringhe");
            Console.ResetColor();

            string frase = "I topi non avevano nipoti";
            string a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] alfabeto = a.ToCharArray();

            Console.WriteLine("La frase è: \t\t{0}", frase);

            string revers = ReversString(frase);
            Console.WriteLine("Frase al contrario: \t{0}", revers);

            int parole = ContaParole(frase);
            Console.WriteLine("Numero di parole nella frase: \t{0}", parole);

            bool palidroma = FrasePalindroma(frase);
            Console.WriteLine("La frase è palindroma: \t{0}", palidroma);

            int[] frequenze = FrequenzeAlfabeto(frase);
            Console.WriteLine("\nlettera: \t frequenza:");
            for (int i = 0; i < frequenze.Length; i++)
                if (frequenze[i] != 0)
                    Console.Write("{0} \t\t {1}\n", alfabeto[i], frequenze[i]);

            //elimino gli spazi sostituendoli con un valore nullo con il metodo .Replace
            string senzaSpazi = frase.Replace(" ", "");
            Console.WriteLine("Frase senza spazi: {0}", senzaSpazi);
        }

        static string ReversString(string frase)
        {
            char[] revers = frase.ToCharArray();
            char[] parola = new char[frase.Length];
            int j = frase.Length;

            for (int i = 0; i < frase.Length; i++)
                parola[i] = revers[--j];

            return new string(parola);
        }

        static int ContaParole(string frase)
        {
            int cont = 1;
            //sostituisco i doppi spazi con uno spazio singolo
            string fraseS = frase.Replace("  ", " ");
            char[] parole = fraseS.ToCharArray();

            for (int i = 0; i < parole.Length; i++)
            {
                //appena trovo uno spazio conto la parola e poi continuo con gli altri caratteri
                if (parole[i] == ' ')
                {
                    cont++;
                }
            }
            return cont;
        }

        static bool FrasePalindroma(string frase)
        {
            bool palindroma = false;

            //converto la frase in minuscolo e gli spazi li sostituisco con 'null'
            string lower = frase.ToLower().Replace(" ", "");
            string parole = ReversString(lower);

            if (string.Compare(parole, lower) == 0)
                palindroma = true;

            return palindroma;
        }

        static int[] FrequenzeAlfabeto(string frase)
        {
            string alfabeto = "abcdefghijklmnopqrstuvwxyz";
            char[] alfabetoControllo = alfabeto.ToCharArray();
            string upper = frase.ToUpper();
            char[] parole = frase.ToCharArray();
            int[] contatore = new int[alfabetoControllo.Length];

            for (int i = 0; i < frase.Length; i++)
            {
                for (int j = 0; j < alfabetoControllo.Length; j++)
                {
                    if (parole[i] == alfabetoControllo[j])
                        contatore[j] = contatore[j] + 1;
                }
            }
            return contatore;
        }
    }
}