using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGenericTypeExample
{
    public class Project : IData<Project>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }


        public void Update(Project source)
        {
            ProjectName = source.ProjectName;
        }
    }
}
