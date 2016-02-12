using application.Entity;
using application.BL.Configuracion;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Proyecto.UnitTest
{
    [TestFixture]
    public class ConfigServiceTest
    {
        [Test]
        public void EncriptaTest() {
            string valor = "sdf";
             
            var repository = Substitute.For<IFuncionGeneral>()
        }
    }
}
