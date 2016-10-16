using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGenericTypeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositories = new RepositoriesFactory();

			var client = repositories.Clients.FindById(1);
			Console.WriteLine("Company Name:{0}", client.CompanyName);

			var project = repositories.Projects.FindById(1);
			Console.WriteLine("Project Name: {0}", project.ProjectName);
			Console.WriteLine(GetTypeName(repositories.Clients.GetType()));
			Console.WriteLine(GetTypeName(repositories.Projects.GetType()));


            Console.ReadKey();
        }
        private static string GetTypeName(Type type)
        {
            return string.Format("{0}<{1}>", type.Name.Replace("`1",""), type.GetGenericArguments()[0]);
        }
    }
}
