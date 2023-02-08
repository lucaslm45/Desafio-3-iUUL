using NovoOdonto.data;
using NovoOdonto.presentation.paciente;
using NovoOdonto.presentation.agendamento;

namespace NovoOdonto.controller
{
    public class MainController
    {
        private readonly MenusPacienteForm PacienteForm;
        private readonly MenusAgendaForm AgendaForm;
        private OdontoDbContext Contexto { get; set; }
        public MainController(OdontoDbContext contexto)
        {
            Contexto = contexto;
            AgendaForm = new();
            PacienteForm = new();
        }

        public void Inicia()
        {
            MenuPrincipal();
        }
        private void MenuPrincipal()
        {
            switch (PacienteForm.MenuPrincipal())
            {
                case "1":
                    MenuCadastraPaciente();
                    break;
                case "2":
                    MenuAgenda();
                    break;
                case "3":
                    Console.WriteLine("\nFim");
                    return;
            }
            MenuPrincipal();
        }

        private void MenuCadastraPaciente()
        {
            switch (PacienteForm.MenuCadastraPaciente())
            {
                case "1":
                    InclusaoPacienteController.Inicia(Contexto);
                    break;
                case "2":
                    ExclusaoPacienteController.Inicia(Contexto);
                    break;
                case "3":
                    ConsultarPacientesController.ListarPorCPF(Contexto);
                    break;
                case "4":
                    ConsultarPacientesController.ListarPorNome(Contexto);
                    break;
                case "5":
                    return;
            }
            MenuCadastraPaciente();
        }
        private void MenuAgenda()
        {
            switch (AgendaForm.MenuAgenda())
            {
                case "1":
                    AgendamentoConsultaController.Inicia(Contexto);
                    break;
                case "2":
                    CancelamentoConsultaController.Inicia(Contexto);
                    break;
                case "3":
                    MenuListarAgenda();
                    break;
                case "4":
                    return;
            }
            MenuAgenda();
        }

        private void MenuListarAgenda()
        {
            switch (AgendaForm.MenuListarAgenda())
            {
                case "1":
                    ConsultarAgendaController.Inicia(Contexto);
                    break;
                case "2":
                    ConsultarAgendaController.IniciaPorPeriodo(Contexto);
                    break;
                case "3":
                    return;

            }
            MenuListarAgenda();
        }
    }
}
