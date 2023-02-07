using Microsoft.EntityFrameworkCore;
using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.presentation.agendamento;
using NovoOdonto.presentation.paciente;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.controller
{
    public class CancelamentoConsultaController
    {
        public static void Inicia(OdontoDbContext contexto)
        {
            bool isValid;
            var Form = new CancelamentoConsultaForm();
            var Validador = new AgendamentoValidador(contexto);

            // CPF
            Form.SolicitarCPF();
            isValid = Validador.IsValidCPF(Form.Agendamento.CPF) &&
                        Validador.Agendamento.CPF.PacienteTemAgendamentoFuturo(contexto);

            if (isValid)
            {
                // Data Cancelamento
                do
                {
                    Form.SolicitarDataConsulta();
                    isValid = Validador.IsValidDataCancelamento(Form.Agendamento.DataConsulta);
                } while (!isValid);
            }
            if (isValid)
            {
                // Hora Cancelamento
                do
                {
                    Form.SolicitarHoraInicio();
                    isValid = Validador.IsValidHoraCancelamento(Form.Agendamento.HoraInicio);
                } while (!isValid);
            }
            if (isValid)
            {
                var dataParaCancelamento = Validador.Agendamento.DataConsulta.FormataStringEmData().ToUniversalTime();
                var horaParaCancelamento = Validador.Agendamento.HoraInicio.FormataStringEmHora();

                var agendamentos = contexto.Agendamentos.Include(p => p.Paciente);

                var consulta = agendamentos.FirstOrDefault(a => a.PacienteId == Validador.Agendamento.CPF
                                                           && a.DataConsulta.Date == dataParaCancelamento.Date
                                                           && a.HoraInicio == horaParaCancelamento);
                if (consulta != null)
                {
                    contexto.Agendamentos.Remove(consulta);
                    contexto.SaveChanges();
                    var dataHoraConsulta = consulta.DataConsulta.Date + consulta.HoraInicio;

                    Console.WriteLine($"Agendamento {dataHoraConsulta} de {consulta.Paciente.Nome} foi excluído!");
                }
                else
                    Console.WriteLine("Erro: Agendamento não encontrado.");
            }
        }
    }
}
