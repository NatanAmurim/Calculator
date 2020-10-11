using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Seja bem-vindo ao teste Calculator!");
            Console.WriteLine("Que tipo de cálculo vamos efetuar hoje?");
            Console.WriteLine("");
            Console.WriteLine("Para soma digite 1:");
            Console.WriteLine("Para subtração digite 2:");
            Console.WriteLine("Para multiplicação digite 3:");
            Console.WriteLine("Para divisão digite 4:");
            Console.WriteLine("Para sair digite 5:");

            int Opcao = Int32.Parse(Console.ReadLine());

            if (Opcao == 5) { System.Environment.Exit(0); }

            var typeCalculation = (ETypeCalculation)Opcao;
            Console.WriteLine("");

            Console.WriteLine("Perfeito! Agora vamos aos valores...");
            Console.WriteLine("Insira o primeiro valor: ");
            float valor1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o segundo valor:");
            float valor2 = float.Parse(Console.ReadLine());
            Console.WriteLine("");

            var calculator = new Calculator(valor1, valor2, typeCalculation);

            Console.WriteLine(calculator.Calculation());
            Console.WriteLine("Obrigado por usar nossa calculadora!");
            Console.ReadKey();
            Menu();

        }
    }

    struct Calculator
    {
        public float Valor1;
        public float Valor2;
        public ETypeCalculation TypeCalculation;

        public Calculator(float valor1, float valor2, ETypeCalculation typeCalculation)
        {
            Valor1 = valor1;
            Valor2 = valor2;
            TypeCalculation = typeCalculation;
        }
        String Somar() { return $"O valor da soma é: {Valor1 + Valor2}"; }
        String Subtrair() { return $"O valor da subtração é:  {Valor1 - Valor2}"; }
        String Multiplicar() { return $"O valor da multiplicação é: {Valor1 * Valor2}"; }
        String Dividir() { return $"O valor da divisão é:  {Valor1 / Valor2}"; }

        public string Calculation()
        {

            switch (TypeCalculation)
            {
                case ETypeCalculation.Somar: return Somar();
                case ETypeCalculation.Subtrair: return Subtrair();
                case ETypeCalculation.Multiplicar: return Multiplicar();
                case ETypeCalculation.Dividir: return Dividir();
                default: return "Não foi possível realizar o cálculo.";
            }
        }

        public bool ValidationTypeCalculation(ETypeCalculation typeCalculation)
        {
            if (ETypeCalculation.IsDefined(typeCalculation))
            {
                return true;
            }
            Console.WriteLine("Tipo de operação inválida. Por favor, tente novamente.");
            return false;
        }
    }

    enum ETypeCalculation
    {
        Somar = 1,
        Subtrair = 2,
        Multiplicar = 3,
        Dividir = 4
    }


}
