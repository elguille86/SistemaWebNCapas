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
        public string valorSimple = "developer";
        public string valorHAS = "56FYpKBhYEaj5q/t4nJTpJteyL4UMdrQtpcVGCQvFik=";
        [TestCase]
        public void EncriptaDatoTest() {
            var repository = Substitute.For<IFuncionGeneral>();
            repository.Encrypt(this.valorSimple).Returns(this.valorHAS);
            Assert.That(repository.Encrypt(this.valorSimple), Is.EqualTo(this.valorHAS));
        }

        [TestCase]
        public void DescriptaDatoTest()
        {
            var repository = Substitute.For<IFuncionGeneral>();
            repository.Decrypt(this.valorHAS).Returns(this.valorSimple);
            Assert.That(repository.Decrypt(this.valorHAS), Is.EqualTo(this.valorSimple));
        }
    }
}
