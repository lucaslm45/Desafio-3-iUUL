using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.data.dto
{
    public class AgendamentoDTO
    {
        private string? cpf;

        public string? CPF
        {
            get { return cpf; }
            set { cpf = value?.Trim(); }
        }

        public string? DataConsulta { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFim { get; set; }
    }
}
