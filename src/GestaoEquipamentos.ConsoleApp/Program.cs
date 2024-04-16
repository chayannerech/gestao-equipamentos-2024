using System.ComponentModel.Design;
namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestão conjuntoEquipamentos = new Gestão();
            conjuntoEquipamentos.PreencherArray();
            string opcao = "neutra";

            do Menu(ref opcao, conjuntoEquipamentos);
            while (!Sair(opcao));
        }

        static void Menu(ref string opcao, Gestão conjuntoEquipamentos)
        {
            do
            {
                Console.Clear();
                opcao = RecebeInformacao("Gestão de Equipamentos\n\nDigite 1 para o Cadastro de Equipamentos\nDigite 2 para o Controle de Chamados\nDigite S para sair\n");
                
                if (opcao == "1") conjuntoEquipamentos.CadastroDeEquipamentos(ref opcao);
                else if (opcao == "2") Console.WriteLine("Ainda não sei");
                else if (!Sair(opcao)) opcao = RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair");
            }
            while (opcao == "");
        }
        static string RecebeInformacao(string texto)
        {
            Console.WriteLine(texto);
            return Console.ReadLine();
        }
        static bool Sair(string opcao)
        {
            return opcao == "s" || opcao == "S";
        }
    }
}
