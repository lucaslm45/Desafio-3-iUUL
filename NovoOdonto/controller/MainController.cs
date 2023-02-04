using NovoOdonto.data;

namespace NovoOdonto.controller
{
    public class MainController
    {
        public MainController(OdontoDbContext contexto)
        {
            Contexto = contexto;
        }

        private OdontoDbContext Contexto { get; set; }

        public void Inicia()
        {
            var Teste = new InclusaoPacienteController(Contexto);
            Teste.Inicia();
        }
    }
}
