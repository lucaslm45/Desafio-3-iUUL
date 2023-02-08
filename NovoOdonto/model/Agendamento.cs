using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoOdonto.presentation.agendamento;
using NovoOdonto.util;
using static System.Net.Mime.MediaTypeNames;

namespace NovoOdonto.model
{
    public class Agendamento
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime DataConsulta { get; set; }
        [Required]
        public TimeSpan HoraInicio { get; set; }
        [Required]
        public TimeSpan HoraFim { get; set; }
        [Required]
        public TimeSpan Tempo { get; set; }
        [Required]
        public virtual Paciente Paciente { get; set; }

        public string PacienteId { get; set; }
        public Agendamento() { }

        /// <summary>
        /// Construtor da classe Agendamento, sendo responsável por fazer as entradas de dados para a Agenda.
        /// </summary>
        /// <param name="data">Recebe data no formato ddmmaaaa</param>
        /// <param name="horaInicio">Recebe a hora inicial do formato hhmm</param>
        /// <param name="horaFim">Recebe a hora final do formato hhmm</param>
        /// <param name="paciente">Recebe objeto paciente ao qual o agendamento será vinculado</param>
        public Agendamento(string data, string horaInicio, string horaFim, Paciente paciente)
        {
            DataConsulta = data.FormataStringEmData();

            HoraInicio = horaInicio.FormataStringEmHora();
            HoraFim = horaFim.FormataStringEmHora();

            Tempo = HoraFim.Subtract(HoraInicio);

            Paciente = paciente;
        }

        public override string ToString()
        {
            return DataConsulta.ToShortDateString().PadCenter((int)EspacosAgenda.Data) +
                   HoraInicio.ToString(@"hh\:mm").PadCenter((int)EspacosAgenda.Tempo) +
                   HoraFim.ToString(@"hh\:mm").PadCenter((int)EspacosAgenda.Tempo) +
                   Tempo.ToString(@"hh\:mm").PadCenter((int)EspacosAgenda.Tempo) +
                   Paciente.Nome.ToString().PadRight((int)EspacosAgenda.Nome) +
                   Paciente.Nascimento.ToShortDateString().PadCenter((int)EspacosAgenda.Data);
        }
    }
}
