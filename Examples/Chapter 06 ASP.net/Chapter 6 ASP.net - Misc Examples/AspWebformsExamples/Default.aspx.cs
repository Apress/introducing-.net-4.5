using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace AspWebformsExamples
{
    public partial class _Default : Page
    {


        public IQueryable<Person> GetPeople([TestBinder] string firstName)
        {

            var v1=Request.Unvalidated.Cookies["myValue"];
            var v2 = Request.Unvalidated.QueryString["myValue"];
            var v3 = Request.Unvalidated.Form["myValue"];


            return null;
        }


        public IQueryable<Person> GetPeople2([QueryString] string firstName)
        {

            var people = new List<Person>(){
                new Person(){
                    ID=1,
                    Age=31,
                    FirstName="Alex",
                    LastName="Mackey"
                },
                new Person(){
                    ID=2,
                    Age=33,
                    FirstName="Belinda",
                    LastName="Lord"
                }

            }.AsQueryable();

            if (!String.IsNullOrWhiteSpace(firstName))
            {
                return people.Where(person => person.FirstName == firstName);
            }
            else
            {
                return people;
            }
        }


        //public IQueryable<Person> GetPeople()
        //{

        //    IQueryable<Person> people = new List<Person>(){
        //    new Person()
        //    {
        //    ID=0,
        //    Age=33,
        //    FirstName="Belinda",
        //    LastName="Lord"
        //    },

        //    new Person()
        //    {
        //    ID=1,
        //    Age=62,
        //    FirstName="Rhonda",
        //    LastName="Lord"
        //    },

        //    new Person()
        //    {
        //    ID=2,
        //    Age=64,
        //    FirstName="Gary",
        //    LastName="Lord"
        //    },

          
        //    new Person()
        //    {
        //    ID=4,
        //    Age=1,
        //    FirstName="Darcy",
        //    LastName="Lord"
        //    },

           

        //    }.AsQueryable();
        //    return people;
        //}

        public void UpdatePeople(Person model)
        {
            var success = TryUpdateModel<Person>(model);
            if (success)
            {
                //TODOwritebackupdate
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;

        }

    }
}
