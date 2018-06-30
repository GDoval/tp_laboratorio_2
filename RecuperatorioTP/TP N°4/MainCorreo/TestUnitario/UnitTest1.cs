using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void DiferentesID()
        {
            Correo correo = new Correo();
            Paquete paq1 = new Paquete("Test", "1234");
            Paquete paq2 = new Paquete("Test2", "1234");
            correo += paq1;
            try
            {
                correo += paq2;
            }
            catch (TrackingIDRepetidoException e)
            {
                Assert.Fail("Trackig ID repetido");
            }
        }
    }
}
