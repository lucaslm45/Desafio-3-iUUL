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
        public AgendamentoValidador() 
        {
            Agendamento = new();
        }
        public AgendamentoDTO Agendamento { get; private set; }



        public bool IsValidCPF(string cpf)
        {
            var contexto = new OdontoDbContext();
            try
            {
                if (!cpf.IsCpf())
                    throw new Exception("Erro: CPF inválido");
                if (!contexto.PacienteExisteNoBanco(cpf))
                    throw new Exception("Erro: CPF não cadastrado");

                Agendamento.CPF = cpf;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }

        public bool IsValidDataConsulta(string data)
        {
            Agendamento.DataConsulta = data;
            return true;
        }

        public bool IsValidHoraInicio(string horaIncio)
        {
            Agendamento.HoraInicio = horaIncio;
            return true;
        }

        public bool IsValidHoraFim(string horaFim) 
        {
            Agendamento.HoraFim = horaFim;
            return true;
        }
    }
}
