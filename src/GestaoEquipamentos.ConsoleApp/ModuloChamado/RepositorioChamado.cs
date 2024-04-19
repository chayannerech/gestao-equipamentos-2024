using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    internal class RepositorioChamado
    {
        int contador = 0;
        public Chamado[] chamados = new Chamado[50];

        public void Cadastrar(string titulo, string descricao, string equipamento)
        {
            chamados[contador] = new Chamado(titulo, descricao, equipamento, contador + 1);
            contador++;
        }
        public string Visualizar()
        {
            string listagem = "";
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null) listagem += $"  {chamados[i].id}\t\t| {chamados[i].titulo}\t\t\t| {chamados[i].descricao}\t\t\t\t| {chamados[i].equipamento}\t\t| {chamados[i].dataAbertura}\n  ------------------------------------------------------------------------------------------------------------\n";
            }
            return listagem;
        }
        public void Editar(int editarIndex, string titulo, string descricao, string equipamento)
        {
            int id = chamados[editarIndex].id;
            chamados[editarIndex] = new Chamado(titulo, descricao, equipamento, id);
        }
        public void Excluir(int excluirID)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null) if (chamados[i].id == excluirID) chamados[i] = null;
            }
        }



        //Auxiliares Visualizar
        public bool ListaEstaVazia()
        {
            for (int i = 0; i < chamados.Length; i++) if (chamados[i] != null) return false;
            return true;
        }

        //Auxiliar de Editar
        public string VisualizarParaEdicao(int editarIndex) => $"  {chamados[editarIndex].id}\t\t| {chamados[editarIndex].titulo}\t\t\t| {chamados[editarIndex].descricao}\t\t\t\t| {chamados[editarIndex].equipamento}\t\t| {chamados[editarIndex].dataAbertura}\n  ------------------------------------------------------------------------------------------------------------\n";
        public void TestaID(string editarID, ref int index, ref string opcao)
        {
            for (int i = 0; i < chamados.Length; i++) if (chamados[i] != null) if (chamados[i].id == Convert.ToInt32(editarID)) index = i;
            if (index == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nO ID não existe. 'Enter' para tentar novamente ou 'S' para sair: ");
                Console.ForegroundColor = ConsoleColor.White;
                opcao = Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
