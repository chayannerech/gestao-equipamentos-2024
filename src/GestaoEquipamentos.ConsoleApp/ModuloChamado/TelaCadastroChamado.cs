using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    internal class TelaCadastroChamado
    {
        TelaCadastroEquipamento equipamentos;

        public TelaCadastroChamado(TelaCadastroEquipamento equipamentos) => this.equipamentos = equipamentos;
        public RepositorioChamado gerirChamados = new RepositorioChamado();

        public void MenuChamados(ref string opcao)
        {
            do
            {
                Console.Clear();
                opcao = equipamentos.RecebeInformacao("Controle de Chamados\n\nDigite 1 para abrir um novo chamado\nDigite 2 para visualizar os chamados abertos\nDigite 3 para editar um chamado\nDigite 4 para excluir um chamado\nDigite S para sair\n\nDigite: ");
                if (opcao == "1") MenuCadastro(ref opcao);
                else if (opcao == "2") MenuVisualizar(ref opcao, "Enter para continuar");
                else if (opcao == "3") MenuEdicao(ref opcao);
                else if (opcao == "4") MenuExcluir(ref opcao);
                else equipamentos.OpcaoInvalida(ref opcao);
            }
            while (opcao == "");
        }

        public void MenuCadastro(ref string opcao)
        {
            Console.Clear();
            Console.WriteLine("Abrindo um novo chamado\n");
            string titulo = equipamentos.RecebeInformacao("Informe o título: ");
            string descricao = equipamentos.RecebeInformacao("Descreva o problema: ");
            string equipamento = TestaIDCadastro(ref opcao);
            if (opcao.ToUpper() != "S")
            {
                gerirChamados.Cadastrar(titulo, descricao, equipamento);
                equipamentos.RealizadoComSucesso("chamado aberto");
            }
        }
        public string MenuVisualizar(ref string opcao, string texto)
        {
            string escolhaDeID = "";
            if (gerirChamados.ListaEstaVazia()) ListaVazia(ref opcao);
            else
            {
                Cabecalho();
                Console.WriteLine(gerirChamados.Visualizar());
                escolhaDeID = equipamentos.RecebeInformacao(texto);
            }
            return escolhaDeID;
        }
        public void MenuEdicao(ref string opcao)
        {
            if (gerirChamados.ListaEstaVazia()) ListaVazia(ref opcao);
            else
            {
                do
                {
                    int editarIndex = -1;
                    do
                    {
                        string editarID = MenuVisualizar(ref opcao, "Qual o numero do chamado que deseja editar? ");
                        gerirChamados.TestaID(editarID, ref editarIndex, ref opcao);
                    }
                    while (editarIndex == -1 && opcao.ToUpper() != "S");

                    if (opcao.ToUpper() == "S") break;
                    var editarObjeto = gerirChamados.chamados[editarIndex];
                    opcao = MenuEditar(opcao, editarIndex, editarObjeto);
                    gerirChamados.Editar(editarIndex, editarObjeto.titulo, editarObjeto.descricao, editarObjeto.equipamento);
                }
                while (opcao.ToUpper() == "R" || opcao.ToUpper() == "");
                if (opcao.ToUpper() != "S") equipamentos.RealizadoComSucesso("chamado editado");
            }
        }
        public void MenuExcluir(ref string opcao)
        {
            if (gerirChamados.ListaEstaVazia()) ListaVazia(ref opcao);
            else
            {
                int excluirIndex = -1;
                do
                {
                    string excluirID = MenuVisualizar(ref opcao, "Qual o número do chamado que deseja excluir? ");
                    gerirChamados.TestaID(excluirID, ref excluirIndex, ref opcao);
                }
                while (excluirIndex == -1);

                gerirChamados.Excluir(excluirIndex + 1);
                equipamentos.RealizadoComSucesso("equipamento excluído");
            }
        }



        //Auxiliar de cadastro
        private string TestaIDCadastro(ref string opcao)
        {
            string equipamento;
            int testaID = -1;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                equipamento = equipamentos.RecebeInformacao("Informe o ID do equipamento: ");
                equipamentos.gerirInventario.TestaID(equipamento, ref testaID, ref opcao);
            }
            while (testaID == -1 && opcao.ToUpper() != "S");
            return equipamento;
        }
        //Auxiliar de visualização
        public void ListaVazia(ref string opcao)
        {
            do
            {
                Console.Clear();
                opcao = equipamentos.RecebeInformacao("Ainda não existem chamados cadastrados\n\nDigite 1 para retornar\nDigite 2 para cadastrar novo chamado\nDigite S para sair\n\nDigite: ");

                if (opcao == "1") MenuChamados(ref opcao);
                else if (opcao == "2") MenuCadastro(ref opcao);
                else equipamentos.OpcaoInvalida(ref opcao);
            }
            while (opcao == "");

        }
        public void Cabecalho()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  Nº chamado\t| Título\t\t| Descrição\t\t\t| Equipamento\t| Data abertura\n  ------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Auxiliar de edição
        string MenuEditar(string opcao, int editarIndex, Chamado editarObjeto)
        {
            Cabecalho();
            opcao = equipamentos.RecebeInformacao(gerirChamados.VisualizarParaEdicao(editarIndex) + "\nDigite 1 para editar o titulo\nDigite 2 para editar a descrição\nDigite 3 para editar o equipamento\n\nDigite R para retornar\n\nDigite: ");

            if (opcao == "1") editarObjeto.titulo = equipamentos.RecebeInformacao("\nInforme o novo título: ");
            else if (opcao == "2") editarObjeto.descricao = equipamentos.RecebeInformacao("\nInforme a nova descrição: ");
            else if (opcao == "3") editarObjeto.equipamento = TestaIDCadastro(ref opcao);
            else if (opcao.ToUpper() == "R") ;
            else equipamentos.OpcaoInvalida(ref opcao);
            return opcao;
        }

    }
}
