using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.model
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public string PacienteId { get; set; }
        public Paciente Paciente { get; set; }

    }
}
