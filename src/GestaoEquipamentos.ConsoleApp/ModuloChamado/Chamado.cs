using System.Runtime.Intrinsics.X86;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    internal class Chamado
    {
        public string titulo, descricao, equipamento, dataAbertura;
        public int id;
        public Chamado(string titulo, string descricao, string equipamento, int id)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.equipamento = equipamento;
            dataAbertura = DateTime.Now.ToString("u");
            this.id = id;
        }
    }
}
