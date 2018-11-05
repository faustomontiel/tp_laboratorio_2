using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void ValidarDniTest()
        {
            try
            {
                Profesor profe = new Profesor(123, "Jose", "Lopez", "99999999", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

        }
    }
}
