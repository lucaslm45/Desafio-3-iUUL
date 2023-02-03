using NovoOdonto.data.dto;
using NovoOdonto.model;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.data.validator
{
    public class PacienteValidador
    {
        public PacienteValidador()
        {
            Paciente = new();
        }

        public PacienteDTO Paciente { get; private set; }
        public bool IsValidCPF(string cpf, OdontoDbContext contexto)
        {
            try
            {
                if (!cpf.IsCpf())
                    throw new Exception("Erro: CPF inválido");
                if (contexto.PacienteExisteNoBanco(cpf))
                    throw new Exception("Erro: CPF já cadastrado");

                Paciente.CPF = cpf;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;

        }
        public bool IsValidNome(string nome)
        {
            try
            {
                nome = nome.Trim();
                if (nome.Length < 5)
                    throw new Exception("Nome deve ter ao menos 5 letras");

                Paciente.Nome = nome;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
        public bool IsValidNascimento(string dataNascimento)
        {
            try
            {
                // Data de nascimento
                var nascimento = dataNascimento.VerificaData();

                if (nascimento > DateTime.Now.AddYears(-13))
                    throw new Exception("O paciente deve ter pelo menos 13 anos na data atual");

                Paciente.DataNascimento = dataNascimento;
            }
            catch (Exception ex)
            {
                return ex.EncerrarProcessoComErro();
            }
            return true;
        }
    }
}
