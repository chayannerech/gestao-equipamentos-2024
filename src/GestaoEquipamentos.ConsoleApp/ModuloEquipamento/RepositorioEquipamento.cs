using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class RepositorioEquipamento
    {
        int contador = 0;
        public Equipamento[] inventario = new Equipamento[50];

        public void Cadastrar(string nome, string precoAquisicao, string numeroSerie, string dataFabricacao, string fabricante)
        {
            inventario[contador] = new Equipamento(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante, contador + 1);
            contador++;
        }
        public string Visualizar()
        {
            string listagem = "";
            for (int i = 0; i < inventario.Length; i++)
            {
                if (inventario[i] != null) listagem += $"  {inventario[i].id}\t| {inventario[i].numeroSerie}\t\t| {inventario[i].nome}\t\t| {inventario[i].precoAquisicao}\t\t| {inventario[i].fabricante}\t\t\t| {inventario[i].dataFabricacao}\n  ----------------------------------------------------------------------------------------------------------\n";
            }
            return listagem;
        }
        public void Editar(int editarIndex, string nome, string precoAquisicao, string numeroSerie, string dataFabricacao, string fabricante)
        {
            int id = inventario[editarIndex].id;
            inventario[editarIndex] = new Equipamento(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante, id);
        }
        public void Excluir(int excluirID)
        {
            for (int i = 0; i < inventario.Length; i++)
            {
                if (inventario[i] != null) if (inventario[i].id == excluirID) inventario[i] = null;
            }
        }

        //Auxiliares de Visualização
        public bool ListaEstaVazia()
        {
            for (int i = 0; i < inventario.Length; i++) if (inventario[i] != null) return false;
            return true;
        }

        //Auxiliares de Edição
        public void TestaID(string editarID, ref int index, ref string opcao)
        {
            for (int i = 0; i < inventario.Length; i++) if (inventario[i] != null) if (inventario[i].id == Convert.ToInt32(editarID)) index = i;
            if (index == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nO ID não existe. 'Enter' para tentar novamente ou 'S' para sair: ");
                opcao = Console.ReadLine();
            }
        }
        public string VisualizarParaEdicao(int editarIndex) => $"  {inventario[editarIndex].id}\t| {inventario[editarIndex].numeroSerie}\t\t| {inventario[editarIndex].nome}\t\t| {inventario[editarIndex].precoAquisicao}\t\t| {inventario[editarIndex].fabricante}\t\t\t| {inventario[editarIndex].dataFabricacao}\n  ----------------------------------------------------------------------------------------------------------\n";
    }
}
