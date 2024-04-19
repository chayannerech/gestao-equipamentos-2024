namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class Equipamento
    {
        public string nome, dataFabricacao, fabricante, numeroSerie, precoAquisicao;
        public int id;

        public Equipamento(string nome, string precoAquisicao, string numeroSerie, string dataFabricacao, string fabricante, int id)
        {
            this.nome = nome;
            this.precoAquisicao = precoAquisicao;
            this.numeroSerie = numeroSerie;
            this.dataFabricacao = dataFabricacao;
            this.fabricante = fabricante;
            this.id = id;
        }
    }
}