using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class TelaCadastroEquipamento
    {
        public RepositorioEquipamento gerirInventario = new RepositorioEquipamento();

        public void MenuEquipamentos(ref string opcao)
        {
            do
            {
                Console.Clear();
                opcao = RecebeInformacao("Cadastro de Equipamentos\n\nDigite 1 para inserir novo equipamento\nDigite 2 para visualizar equipamentos\nDigite 3 para editar um equipamento\nDigite 4 para excluir um equipamento\nDigite S para sair\n\nDigite: ");
                if (opcao == "1") MenuCadastro();
                else if (opcao == "2") MenuVisualizar(ref opcao, "Enter para continuar ");
                else if (opcao == "3") MenuEdicao(ref opcao);
                else if (opcao == "4") MenuExcluir(ref opcao);
                else OpcaoInvalida(ref opcao);
            }
            while (opcao == "");
        }

        public void MenuCadastro()
        {
            Console.Clear();
            Console.WriteLine("Registrando um novo equipamento");
            string nome = TestaNome();
            string precoAquisicao = RecebeInformacao("Informe o preço de aquisição: R$ ");
            string numeroSerie = RecebeInformacao("Informe o número de série: ");
            string dataFabricacao = RecebeInformacao("Informe a data de fabricação: ");
            string fabricante = RecebeInformacao("Informe o fabricante: ");
            gerirInventario.Cadastrar(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante);
            RealizadoComSucesso("cadastrado");
        }
        public string MenuVisualizar(ref string opcao, string texto)
        {
            string escolhaDeID = "";

            if (gerirInventario.ListaEstaVazia()) ListaVazia(ref opcao);
            else
            {
                Cabecalho();
                Console.WriteLine(gerirInventario.Visualizar());
                escolhaDeID = RecebeInformacao(texto);
            }
            return escolhaDeID;
        }
        public void MenuEdicao(ref string opcao)
        {
            if (gerirInventario.ListaEstaVazia()) ListaVazia(ref opcao);
            else
            {
                do
                {
                    string editarID = MenuVisualizar(ref opcao, "Qual o ID do equipamento que deseja editar? ");
                    int editarIndex = gerirInventario.EditarIndex(editarID);
                    var editarObjeto = gerirInventario.inventario[editarIndex];

                    opcao = MenuEditar(opcao, editarIndex, editarObjeto);
                    gerirInventario.Editar(editarIndex, editarObjeto.nome, editarObjeto.precoAquisicao, editarObjeto.numeroSerie, editarObjeto.dataFabricacao, editarObjeto.fabricante);
                }
                while (opcao.ToUpper() == "R" || opcao.ToUpper() == "");
                if (opcao.ToUpper() != "S") RealizadoComSucesso("editado");
            }
        }
        public void MenuExcluir(ref string opcao)
        {
            if (gerirInventario.ListaEstaVazia()) ListaVazia(ref opcao);
            else
            {
                int excluirID = Convert.ToInt32(MenuVisualizar(ref opcao, "Qual o ID do equipamento que deseja excluir? "));
                gerirInventario.Excluir(excluirID);
                RealizadoComSucesso("exluído");
            }
        }



        //Auxiliares gerais
        public string RecebeInformacao(string texto)
        {
            Console.Write(texto);
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
        public void OpcaoInvalida(ref string opcao)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (opcao.ToUpper() != "S") opcao = RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair: ");
        }

        //Auxiliares de Cadastro
        public string TestaNome()
        {
            string nome = "";
            while (nome.Length < 6)
            {
                nome = RecebeInformacao("\nInforme o nome do equipamento: ");

                if (nome.Length < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Inválido. Enter para tentar novamente");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
            }
            return nome;
        }
        public void RealizadoComSucesso(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nEquipamento {texto} com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        //Auxiliar de Visualização
        public void ListaVazia(ref string opcao)
        {
            do
            {
                Console.Clear();
                opcao = RecebeInformacao("Ainda não existem equipamentos cadastrados :(\n\nDigite 1 para retornar\nDigite 2 para cadastrar novo equipamento\nDigite S para sair\n\nDigite: ");

                if (opcao == "1") MenuEquipamentos(ref opcao);
                else if (opcao == "2") MenuCadastro();
                else OpcaoInvalida(ref opcao);
            }
            while (opcao == "");

        }
        public void Cabecalho()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  Id\t| Número\t| Nome\t\t\t| Preço\t\t| Fabricante\t\t| Data de fabricação\n  ----------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Auxiliar de Edição
        string MenuEditar(string opcao, int editarIndex, Equipamento editarObjeto)
        {
            Cabecalho();
            opcao = RecebeInformacao(gerirInventario.VisualizarParaEdicao(editarIndex) + "\nDigite 1 para editar o número de série\nDigite 2 para editar o nome\nDigite 3 para editar o preço\nDigite 4 para editar o fabricante\nDigite 5 para editar a data de fabricação\n\nDigite R para retornar\n\nDigite: ");

            if (opcao == "1") editarObjeto.numeroSerie = RecebeInformacao("\nInforme o novo número de série: ");
            else if (opcao == "2") editarObjeto.nome = TestaNome();
            else if (opcao == "3") editarObjeto.precoAquisicao = RecebeInformacao("\nInforme o novo preço de aquisição: ");
            else if (opcao == "4") editarObjeto.fabricante = RecebeInformacao("\nInforme o novo fabricante: ");
            else if (opcao == "5") editarObjeto.dataFabricacao = RecebeInformacao("\nInforme a nova data de aquisição ");
            else if (opcao.ToUpper() == "R") ;
            else OpcaoInvalida(ref opcao);
            return opcao;
        }
    }
}
