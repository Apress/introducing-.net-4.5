using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace OpenGenericTypeExample
{
	public class DummyData
	{
		[Export]
		public IList<Client> FakeClientData { get { return GetFakeClientData(); } }
		[Export]
		public IList<Project> FakeProjectData { get { return GetFakeProjectData(); } }

		private IList<Client> GetFakeClientData()
		{
			return new List<Client> { 
							new Client { Id = 1, 
										 CompanyName = "The Factory", 
										 ContactName = "Andy Warhol" } };
		}

		private IList<Project> GetFakeProjectData()
		{
			return new List<Project>{
							new Project{Id = 1, 
										ProjectName="Cambell Soup Cans"}};
		}
	}
}
