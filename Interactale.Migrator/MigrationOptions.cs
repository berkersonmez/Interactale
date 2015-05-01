using FluentMigrator;

namespace Interactale.Migrator
{
    public class MigrationOptions : IMigrationProcessorOptions
    {
        public bool PreviewOnly { get; set; }
        public int Timeout { get; set; }
        public string ProviderSwitches { get; set; }
    }
}
