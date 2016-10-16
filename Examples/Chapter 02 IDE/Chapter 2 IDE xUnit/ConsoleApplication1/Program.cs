using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    
    
    public class Class1
    {

        [Fact]
        public void The_Sky_Should_Be_Blue()
        {
            const string expected = "Blue";
            string actual = "Blue";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void One_Plus_One_Should_Equal_Two_Or_Does_It()
        {
            Assert.Equal(1 + 1, 3);
        }
    }


}
