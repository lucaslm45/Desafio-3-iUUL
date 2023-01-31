using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.model
{
    public class Paciente
    {
        public Agendamento Agendamento { get; set; }
        public object AgendamentoId { get; internal set; }
    }
}
