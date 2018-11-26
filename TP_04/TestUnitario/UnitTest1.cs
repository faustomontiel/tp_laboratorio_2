using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorreoInstanciadoTest()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
        [TestMethod]
        public void TrackinRepetidoTest()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Formosa 2407","2807");
            Paquete p2 = new Paquete("Lavalle 753 2º piso 7B", "2807");

            try
            {
                correo += p1;
                correo += p2;
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e,typeof(TrackingRepetidoException));
            }
        }
    }
}
