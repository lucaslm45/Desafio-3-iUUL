using NovoOdonto.presentation.paciente;
using static System.Net.Mime.MediaTypeNames;

namespace NovoOdonto.data.dto
{
    public class PacienteDTO
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public int Idade { get; }

    }
}
