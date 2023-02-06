using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoOdonto.util;
using static System.Net.Mime.MediaTypeNames;

namespace NovoOdonto.model
{
    public class Agendamento
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public virtual Paciente Paciente { get; set; }

        [Required]
        public string HoraInicio { get; set; }

        public string Data { get; set; }

        [Required]
        public string HoraFim { get; set; }

        public Agendamento() { }

        public Agendamento(Paciente paciente, string horaInicial, string horaFinal, string data)
        {
            Paciente = paciente;
            HoraInicio = horaInicial;
            HoraFim = horaFinal;
            Data = data;
        }
    }
}
