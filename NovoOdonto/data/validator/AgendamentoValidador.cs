using NovoOdonto.data.dto;
using NovoOdonto.model;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.data.validator
{
    public class AgendamentoValidador
    {
        readonly private TimeSpan is15Minutos;
        private OdontoDbContext Contexto { get; set; }
        public TimeSpan AbreAs { get; private set; }
        public TimeSpan FechaAs { get; private set; }

        public AgendamentoValidador(OdontoDbContext contexto)
        {
            Contexto = contexto;
            AbreAs = new TimeSpan(8, 0, 0);
            FechaAs = new TimeSpan(18, 45, 0);
            is15Minutos = new TimeSpan(0, 15, 0);
        }
        public AgendamentoDTO Agendamento { get; private set; } = new AgendamentoDTO();

        public bool IsValidCPF(string cpf)
        {
            try
            {
                if (!cpf.IsCpf())
                    throw new Exception("Erro: CPF inválido");
                if (!Contexto.PacienteExisteNoBanco(cpf))
                    throw new Exception("Erro: CPF não cadastrado");

                Agendamento.CPF = cpf;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }

        /// <summary>
        /// Faz as validações necessárias para a data de consulta informada.
        /// </summary>
        /// <param name="strConsulta">Representa o valor da data de consulta informada.</param>
        /// <returns>Retorna um valor verdadeiro se a data de consulta for válida.</returns>
        public bool IsValidDataConsulta(string strConsulta)
        {
            // Data de Consulta
            try
            {
                var DataConsulta = strConsulta.VerificaData();
                if (DataConsulta.Date < DateTime.Now.Date)
                    throw new Exception("Erro: data da consulta não deve ser menor que a data de hoje");

                Agendamento.DataConsulta = strConsulta;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        /// <summary>
        /// Faz as validações necessárias para uma data de consulta a ser cancelada.
        /// </summary>
        /// <param name="strConsulta"></param>
        /// <returns>Retorna um valor verdadeiro se a data de consulta for válida.</returns>
        public bool IsValidDataCancelamento(string strConsulta)
        {
            // Data de Consulta
            try
            {
                var DataConsulta = strConsulta.VerificaData();

                Agendamento.DataConsulta = strConsulta;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        /// <summary>
        /// Faz as validações necessárias para uma hora de consulta a ser cancelada.
        /// </summary>
        /// <param name="strConsulta"></param>
        /// <returns>Retorna um valor verdadeiro se a data de consulta for válida.</returns>
        public bool IsValidHoraCancelamento(string strHoraConsulta)
        {
            // Data de Consulta
            try
            {
                var DataConsulta = strHoraConsulta.VerificaHora();

                Agendamento.HoraInicio = strHoraConsulta;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        /// <summary>
        /// Faz as validações necessárias para o horário de início da consulta.
        /// </summary>
        /// <param name="strInicio">Representa o valor da hora de início da consulta.</param>
        /// <returns>Retorna um valor verdadeiro se a hora de início for válida.</returns>
        public bool IsValidHoraInicio(string strInicio)
        {
            // Data de Consulta
            try
            {
                var HoraInicio = strInicio.VerificaHora();
                if (HoraInicio < AbreAs)
                    throw new Exception($"Erro: A clínica irá abrir apenas às {AbreAs:hh\\:mm}.");
                if (HoraInicio > FechaAs)
                    throw new Exception($"Erro: O último horário de início disponível é às {FechaAs:hh\\:mm}.");

                var DataConsulta = Agendamento.DataConsulta.FormataStringEmData().Date;

                if (DataConsulta == DateTime.Now.Date && HoraInicio <= DateTime.Now.TimeOfDay)
                    throw new Exception("Erro: Hora da consulta deve ser maior que a hora atual");

                var consultaData = Agendamento.DataConsulta.FormataStringEmData().Date;

                // Busca todos os agendamentos na data escolhida
                var agendamentos = Contexto.Agendamentos.Where(a => a.DataConsulta.Date == consultaData);

                // Existe algum agendamento com a mesma hora de inicio?
                if (agendamentos.AsEnumerable().Any(a => a.HoraInicio == HoraInicio))
                    throw new Exception($"Erro: Este horário de início não está disponível");

                Agendamento.HoraInicio = strInicio;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }

        /// <summary>
        /// Faz as validações necessárias para o horário de término da consulta.
        /// </summary>
        /// <param name="strFim">Representa o valor da hora de término da consulta.</param>
        /// <returns>Retorna um valor verdadeiro se a hora de término for válida.</returns>
        public bool IsValidHoraFim(string strFim)
        {
            try
            {
                // Data de Consulta
                var HoraFim = strFim.VerificaHora();

                var horarioFechada = FechaAs.Add(is15Minutos);
                if (HoraFim > horarioFechada)
                    throw new Exception($"Erro: A clínica irá fechar às {horarioFechada:hh\\:mm}.");
                if (HoraFim <= Agendamento.HoraInicio.FormataStringEmHora())
                    throw new Exception($"Erro: O horário final da consulta deve ser maior que o inicial.");

                Agendamento.HoraFim = strFim;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        /// <summary>
        /// Valida se há horário disponível na data de consulta escolhida
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="agendamentos"></param>
        /// <returns></returns>
        public bool IsAgendamentoDisponivel()
        {
            try
            {
                var inicio = Agendamento.HoraInicio.FormataStringEmHora();
                var fim = Agendamento.HoraFim.FormataStringEmHora();
                var consultaData = Agendamento.DataConsulta.FormataStringEmData().Date;
                var periodoAgendado = new Intervalo(consultaData + inicio, consultaData + fim);

                var agendamentos = Contexto.Agendamentos.Where(a => a.DataConsulta.Date == consultaData);

                agendamentos = agendamentos.Where(a => a.HoraInicio >= inicio);

                var temIntersecao = agendamentos.AsEnumerable().Any(a => periodoAgendado.TemIntersecao(
                    new Intervalo(a.DataConsulta.Date + a.HoraInicio, a.DataConsulta.Date + a.HoraFim)));

                if (temIntersecao)
                    throw new Exception($"Erro: O horário de agendamento não está disponível.");

            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
    }
}
