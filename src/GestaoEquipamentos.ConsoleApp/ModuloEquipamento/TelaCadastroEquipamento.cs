using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class TelaCadastroEquipamento
    {
        public RepositorioEquipamento inventario = new RepositorioEquipamento();

        public void Menu(ref string opcaoMenu)
        {
            do
            {
                Console.Clear();
                opcaoMenu = inventario.RecebeInformacao("Gestão de Equipamentos\n\nDigite 1 para o Cadastro de Equipamentos\nDigite 2 para o Controle de Chamados\nDigite S para sair\n");

                if (opcaoMenu == "1") MenuCadastroDeEquipamentos(ref opcaoMenu);
                else if (opcaoMenu == "2") Console.WriteLine("Ainda não sei");
                else if (!inventario.Sair(opcaoMenu, "S")) opcaoMenu = inventario.RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair\n");
            }
            while (opcaoMenu == "");
        }
        public void MenuCadastroDeEquipamentos(ref string opcao)
        {
            do
            {
                Console.Clear();
                string opcaoCadastro = inventario.RecebeInformacao("Cadastro de Equipamentos\n\nDigite 1 para inserir novo equipamento\nDigite 2 para visualisar equipamentos\nDigite 3 para editar um equipamento\nDigite 4 para excluir um equipamento\nDigite S para sair\n");
                if (opcaoCadastro == "1") NovoEquipamento();
                else if (opcaoCadastro == "2") Acao(() => inventario.MostrarEquipamentos(ref opcaoCadastro), ref opcaoCadastro);
                else if (opcaoCadastro == "3") Acao(() => inventario.Editar(ref opcaoCadastro), ref opcaoCadastro);
                else if (opcaoCadastro == "4") Acao(() => inventario.Excluir(ref opcaoCadastro), ref opcaoCadastro);
                else if (!inventario.Sair(opcaoCadastro, "S")) opcaoCadastro = inventario.RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair\n");
                opcao = opcaoCadastro;
            }
            while (opcao == "");
        }
        public void NovoEquipamento()
        {
            string nome = inventario.TestaNome();
            string precoAquisicao = inventario.RecebeInformacao("Informe o preço de aquisição: R$ ");
            string numeroSerie = inventario.RecebeInformacao("Informe o número de série: ");
            string dataFabricacao = inventario.RecebeInformacao("Informe a data de fabricação: ");
            string fabricante = inventario.RecebeInformacao("Informe o fabricante: ");
            inventario.Cadastrar(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante);
            CadastradoComSucesso();
        }
        public void MenuSemEquipamentos(ref string opcaoSemEquipamento)
        {
            do
            {
                Console.Clear();
                opcaoSemEquipamento = inventario.RecebeInformacao("Ainda não existem equipamentos cadastrados :(\n\nDigite 1 para retornar\nDigite 2 para cadastrar novo equipamento\nDigite S para sair\n");

                if (opcaoSemEquipamento == "1") MenuCadastroDeEquipamentos(ref opcaoSemEquipamento);
                else if (opcaoSemEquipamento == "2") NovoEquipamento();
                else if (!inventario.Sair(opcaoSemEquipamento, "S")) opcaoSemEquipamento = inventario.RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair\n");
            }
            while (opcaoSemEquipamento == "");
        }

        //Auxiliares
        public void CadastradoComSucesso()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEquipamento cadastrado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public void Acao(Action acao, ref string opcaoCadastro)
        {
            acao();
            if (opcaoCadastro == "vazio") MenuSemEquipamentos(ref opcaoCadastro);
        }
    }
}
