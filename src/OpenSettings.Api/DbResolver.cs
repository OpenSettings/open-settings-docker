using Microsoft.EntityFrameworkCore;
using OpenSettings.Migrations.Shared;

namespace OpenSettings.Api
{
    public class DbResolver
    {
        private DbResolver() { }

        public DbProviderType ProviderType { get; private init; }

        public string AssemblyName { get; private init; }

        public string ConnectionString { get; private init; }

        public void UseDb(DbContextOptionsBuilder optsBuilder)
        {
            switch (ProviderType)
            {
                case DbProviderType.MySql:

                    optsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString), b => b.MigrationsAssembly(AssemblyName));

                    break;

                case DbProviderType.Oracle:

                    optsBuilder.UseOracle(ConnectionString, b =>
                    {
                        b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19);
                        b.MigrationsAssembly(AssemblyName);
                    });

                    break;

                case DbProviderType.PostgreSql:

                    optsBuilder.UseNpgsql(ConnectionString, b => b.MigrationsAssembly(AssemblyName));

                    break;

                case DbProviderType.Sqlite:

                    optsBuilder.UseSqlite(ConnectionString, b => b.MigrationsAssembly(AssemblyName));

                    break;

                case DbProviderType.SqlServer:

                    optsBuilder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly(AssemblyName));

                    break;

                case DbProviderType.InMemory:
                default:

                    optsBuilder.UseInMemoryDatabase(ConnectionString);

                    break;
            }
        }

        public static DbResolver Resolve(IConfiguration configuration)
        {
            var commandLineArgs = Environment.GetCommandLineArgs();

            DbProviderType dbProviderType;

            if (commandLineArgs.FirstOrDefault()?.EndsWith("ef.dll") ?? false)
            {
                var assemblyNameIndex = Array.IndexOf(commandLineArgs, "--root-namespace") + 1;

                var assemblyName = commandLineArgs[assemblyNameIndex];

                dbProviderType = GetDbProviderType(assemblyName);

                return new DbResolver
                {
                    ProviderType = dbProviderType,
                    AssemblyName = assemblyName,
                    ConnectionString = GetLocalConnectionString(dbProviderType)
                };
            }

            var connectionString = configuration["Configuration:ConnectionString"];
            var dbProviderName = configuration["Configuration:DbProviderName"];
            dbProviderType = GetDbProviderType(dbProviderName);

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                return new DbResolver
                {
                    ProviderType = dbProviderType,
                    AssemblyName = GetAssemblyName(dbProviderType),
                    ConnectionString = connectionString
                };
            }
                
            if (dbProviderType != DbProviderType.InMemory)
            {
                throw new InvalidOperationException("Connection string is required for non-in-memory databases.");
            }

            connectionString = "OpenSettings";

            return new DbResolver
            {
                ProviderType = dbProviderType,
                AssemblyName = GetAssemblyName(dbProviderType),
                ConnectionString = connectionString
            };
        }

        private static DbProviderType GetDbProviderType(string name)
        {
            var typeOfDbProviderType = typeof(DbProviderType);

            if (Enum.TryParse(typeOfDbProviderType, name, ignoreCase: true, out var dbProviderType) && 
                Enum.IsDefined(typeOfDbProviderType, dbProviderType))
            {
                return (DbProviderType)dbProviderType;
            }

            return name switch
            {
                Migrations.MySql.Reference.AssemblyName => DbProviderType.MySql,
                Migrations.Oracle.Reference.AssemblyName => DbProviderType.Oracle,
                Migrations.PostgreSql.Reference.AssemblyName => DbProviderType.PostgreSql,
                Migrations.Sqlite.Reference.AssemblyName => DbProviderType.Sqlite,
                Migrations.SqlServer.Reference.AssemblyName => DbProviderType.SqlServer,
                _ => DbProviderType.InMemory
            };
        }

        private static string GetAssemblyName(DbProviderType dbProviderType)
        {
            return dbProviderType switch
            {
                DbProviderType.MySql => Migrations.MySql.Reference.AssemblyName,
                DbProviderType.Oracle => Migrations.Oracle.Reference.AssemblyName,
                DbProviderType.PostgreSql => Migrations.PostgreSql.Reference.AssemblyName,
                DbProviderType.Sqlite => Migrations.Sqlite.Reference.AssemblyName,
                DbProviderType.SqlServer => Migrations.SqlServer.Reference.AssemblyName,
                _ => string.Empty
            };
        }

        private static string GetLocalConnectionString(DbProviderType providerType)
        {
            return providerType switch
            {
                DbProviderType.MySql => "Server=localhost;Port=3306;Database=OpenSettings;Uid=root;Pwd=Passw0rd123*",
                DbProviderType.Oracle => "Data Source=localhost:1521/XE;User Id=system;Password=Passw0rd123*",
                DbProviderType.PostgreSql => "Server=localhost;Port=5432;Database=OpenSettings;User Id=postgres;Password=Passw0rd123*",
                DbProviderType.Sqlite => "Data Source=OpenSettings.db",
                DbProviderType.SqlServer => "Server=localhost,1433;Database=OpenSettings;User Id=sa;Password=Passw0rd123*;TrustServerCertificate=True",
                _ => "OpenSettings",
            };
        }
    }
}