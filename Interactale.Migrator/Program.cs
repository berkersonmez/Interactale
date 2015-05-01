using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;

namespace Interactale.Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var announcer = new TextWriterAnnouncer(s => Debug.WriteLine(s));
            var assembly = Assembly.GetExecutingAssembly();

            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = "Interactale.Migrator.Migrations"
            };

            var options = new MigrationOptions {PreviewOnly = false, Timeout = 60};
            var factory = new SqlServer2012ProcessorFactory();
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var processor = factory.Create(connectionString, announcer, options);
            var runner = new MigrationRunner(assembly, migrationContext, processor);
            runner.MigrateUp(true);
            Console.WriteLine("MIGRATION COMPLETE!");
            Console.ReadLine();
        }
    }
}
