using System.Collections;
using Bosphorus.Configuration.Core;
using Bosphorus.Logging.Database.Configuration;
using Bosphorus.Logging.Model;

namespace Aras.Common.Customization.Bosphorus.Logging.Database.Configuration
{
    public class DatabaseLoggerConfiguration<TLog> : AbstractDatabaseLoggerConfiguration<TLog> 
        where TLog : ILog
    {
        private readonly IDictionary dictionary;

        public DatabaseLoggerConfiguration(IParameterProvider parameterProvider) 
            : base(parameterProvider)
        {
            dictionary = new Hashtable();
            dictionary.Add("SessionAlias", "Default");
        }

        public override IDictionary SessionManagerCreationArguments
        {
            get { return dictionary; }
        }
    }
}

