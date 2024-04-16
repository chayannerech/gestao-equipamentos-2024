using System.ComponentModel.Design;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestão conjuntoEquipamentos = new Gestão();
            conjuntoEquipamentos.PreencherArray();
            while (true)
            {
                Console.Clear();
                string opcao = "";
                Menu(ref opcao, ref conjuntoEquipamentos);
                if (Sair(opcao)) break;
            }
        }
        static void Menu(ref string opcao, ref Gestão conjuntoEquipamentos)
        {
            opcao = conjuntoEquipamentos.equipamentos[0].RecebeInformacao("Gestão de Equipamentos\n\nDigite 1 para o Cadastro de Equipamentos\nDigite 2 para o Controle de Chamados\nDigite S para sair\n");
            if (opcao == "1") conjuntoEquipamentos.CadastroDeEquipamentos(ref opcao);
            else if (opcao == "2") Console.WriteLine("Ainda não sei");
            else if (Sair(opcao)) { }
            else Console.WriteLine("Opção inválida. Tente novamente");
        }
        static bool Sair(string opcao)
        {
            return opcao == "s" || opcao == "S";
        }
    }
}
