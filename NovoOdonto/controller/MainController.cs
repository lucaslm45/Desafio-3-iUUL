using AutoMapper;
using NovoOdonto.data;
using NovoOdonto.Infrastructure;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.controller
{
    public class MainController : IController
    {
        public MainController()
        {
            Contexto = new OdontoDbContext();
            Teste = new InclusaoPacienteController();
        }

        protected OdontoDbContext Contexto { get; set; }
        public InclusaoPacienteController Teste { get; set; }

        public void Inicia()
        {
            var context = new OdontoDbContext();
            context.IniciaBanco();
            Teste.Roda();

        }
    }
}
