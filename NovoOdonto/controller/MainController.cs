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
                    Console.WriteLine("Fim");
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
                    ExclusaoPacienteController.ExcluirPaciente(Contexto);
                    break;
                case "3":
                    Console.WriteLine("ListarPacientesPorCPF not implemented\n");
                    //ListaPacientes.ListarPacientesPorCPF();
                    break;
                case "4":
                    Console.WriteLine("ListarPacientesPorNome not implemented\n");
                    //ListaPacientes.ListarPacientesPorNome();
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
                    Console.WriteLine("//2 - Cancelar agendamento (NotImplemented)\n");
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
                    Console.WriteLine("//1 - Listar toda agenda\n");
                    break;
                case "2":
                    Console.WriteLine("//2 - Listar agenda periodo (NotImplemented)\n");
                    break;
                case "3":
                    return;

            }
            MenuListarAgenda();
        }
    }
}
