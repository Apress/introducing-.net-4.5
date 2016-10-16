using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Contracts;
using Windows.UI.Xaml.Controls;

namespace Win8ConventionBuilder
{
    public class Factory
    {
        private ContainerConfiguration _Configuration;
        private ConventionBuilder _ConventionBuilder;
     
        public TilesContainer TilesContainer { get; private set; }


        /// <summary>
        /// Initializes a new instance of the Factory class.
        /// </summary>
        public Factory()
        {
            _ConventionBuilder = new ConventionBuilder();

            _ConventionBuilder.ForTypesMatching(x => x.Name.EndsWith("Tile"))
                .Export<ITileViewModel>(builder => builder.AsContractName("Tile"));
          
            _ConventionBuilder.ForType<Logger>().Export();

            _ConventionBuilder.ForType<TilesContainer>().Export();

            _ConventionBuilder.ForType<TilesContainer>().ImportProperty(tc => tc.MessageLogger);

            _Configuration = new ContainerConfiguration().WithAssembly(typeof(App).GetTypeInfo().Assembly).WithDefaultConventions(_ConventionBuilder);

            using (var container = _Configuration.CreateContainer())
            {
                try
                {
                    TilesContainer = container.GetExport<TilesContainer>();
                }
                catch (Exception ex)
                {
                    Debugger.Break();
                }
            }
        }
      
    }
}
