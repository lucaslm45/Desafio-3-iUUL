using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.model
{
    public class Agenda
    {
        private readonly List<Agendamento> agendamentos;

        public Agenda()
        {
            agendamentos = new List<Agendamento>();
        }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            agendamentos.Add(agendamento);
        }

        public void RemoverAgendamento(Agendamento agendamento)
        {
            agendamentos.Remove(agendamento);
        }

        public List<Agendamento> ListarAgendamentos()
        {
            return agendamentos;
        }
    }
}
