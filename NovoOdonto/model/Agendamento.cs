﻿using System;
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
        public DateTime DataConsulta { get; set; }
        [Required]
        public TimeSpan HoraInicio { get; set; }
        [Required]
        public TimeSpan HoraFim { get; set; }
        public TimeSpan Tempo { get; }
        [Required]
        public virtual Paciente Paciente { get; set; }

        public string PacienteId { get; set; }
        public Agendamento() { }

        public Agendamento(string data, string horaInicio, string horaFim, Paciente paciente)
        {
            Paciente = paciente;
            HoraInicio = horaInicio.VerificaHora();
            HoraFim = horaFim.VerificaHora();
            DataConsulta = data.FormataStringEmData();
        }
    }
}
