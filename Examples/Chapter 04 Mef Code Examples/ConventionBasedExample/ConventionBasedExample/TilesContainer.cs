using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConventionBasedExample.Contracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.ComponentModel.Composition.Registration;
using System.IO;


namespace ConventionBasedExample
{
    public class TilesContainer
    {
        [ImportMany("Tile")]
        public IEnumerable<ITileViewModel> Tiles { get; set; }

        /// <summary>
        /// Initializes a new instance of the TilesContainer class.
        /// </summary>
        public TilesContainer()
        {
            var registrationBuilder = new RegistrationBuilder();
            registrationBuilder.ForTypesMatching(x => x.Name.EndsWith("Tile")).Export<ITileViewModel>(builder => builder.AsContractName("Tile"));
            registrationBuilder.ForType<Logger>().Export();
           
            var aggregateCatalog = new AggregateCatalog();
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly(), registrationBuilder);
            var path = Directory.GetCurrentDirectory();
            var directoryCatalog = new DirectoryCatalog(path, registrationBuilder);
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            aggregateCatalog.Catalogs.Add(directoryCatalog);

            var container = new CompositionContainer(aggregateCatalog);

            container.ComposeParts(this);
        }
    }
}
