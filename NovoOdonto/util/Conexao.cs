
namespace NovoOdonto.util
{
    public static class Conexao
    {
        private const string Host = "localhost";
        private const string Port = "5432";
        private const string Database = "Consultorio";
        private const string Username = "postgres";
        private const string Password = "root";

        public const string ConnectionString = $"Host={Host};Port={Port};Database={Database};" +
            $"Username={Username};Password={Password}";
    }
}
