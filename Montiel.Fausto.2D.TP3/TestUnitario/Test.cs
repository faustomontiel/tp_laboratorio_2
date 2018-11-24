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
        /// <summary>
        /// Verifica que sea una excepcion de tipo NacionalidadInvalidaException.
        /// </summary>
        [TestMethod]
        public void NacionalidInvalidaExceptionTest()
        {
            try
            {
                Profesor profe = new Profesor(123, "Jose", "Lopez", "99999999", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }
        /// <summary>
        /// El objeto alumno no contiene atributos.
        /// </summary>
        [TestMethod]
        public void AtributosInvalidosException()
        {       
            Alumno alumno = new Alumno();
            Assert.IsNull(alumno.Apellido);
            Assert.IsNull(alumno.Nombre);
         
        }
        /// <summary>
        /// Toma en cuanta los caracteres del dni para lanzar la excepcion DniInvalido.
        /// </summary>
        [TestMethod]
        public void DniInvalidoExceptionTest()
        {
            try
            {
                Profesor profe = new Profesor(123, "Jose", "Lopez", "9eeeee99", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

        }

        /// <summary>
        /// Se agregan dos alumnos con los mismos datos a la universidad, forzando la excepcion AlumnoRepetido.
        /// </summary>
        [TestMethod]
        public void AlumnoRepetidoException()
        {
          Universidad uni = new Universidad();
          Alumno alumnoUno = new Alumno(123, "Jose", "Perez", "44707505",Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,Alumno.EEstadoCuenta.AlDia);
          Alumno alumnoDos = new Alumno(123, "Jose", "Perez", "44707505",Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,Alumno.EEstadoCuenta.AlDia);
            try
            {
                uni += alumnoUno;
                uni += alumnoDos;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }

        }
    }
}
