using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using ClasesInstanciables;

public class Alumno : Universitario
{

    public enum EEstadoCuenta
    {
        AlDia,
        Deudor,
        Becado
    }
    #region Atributos
    private Universidad.EClases clasesQueToma;
    private EEstadoCuenta estadoCuneta;
    #endregion 

    #region Constructores
    /// <summary>
    /// Constructor.
    /// </summary>
    public Alumno()
    {
    }
    /// <summary>
    /// Constructor de instancia.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nombre"></param>
    /// <param name="apellido"></param>
    /// <param name="dni"></param>
    /// <param name="nacionalidad"></param>
    /// <param name="clasesQueToma"></param>
    public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
    : base(id, nombre, apellido, dni, nacionalidad)
    {
        this.clasesQueToma = clasesQueToma;
    }
    /// <summary>
    /// construcor de instancia.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nombre"></param>
    /// <param name="apellido"></param>
    /// <param name="dni"></param>
    /// <param name="nacionalidad"></param>
    /// <param name="clasesQueToma"></param>
    /// <param name="estadoCuenta"></param>
    public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
    : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
    {
        this.estadoCuneta = estadoCuenta;
    }
    #endregion

    #region Metodos
    /// <summary>
    /// Muestra los datos del alumno, asi como su estado de cuenta y participacion.
    /// </summary>
    /// <returns></returns>
    protected override string MostrarDatos()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.MostrarDatos());
        if (this.estadoCuneta == EEstadoCuenta.AlDia)
        {
            sb.AppendFormat("ESTADO DE CUENTA: Cuota Al dia ");
        }
        else
        {
            sb.AppendFormat("ESTADO DE CUENTA:{0} ", this.estadoCuneta);
        }
        sb.AppendLine(ParticiparEnClase());
        return sb.ToString();
    }
    /// <summary>
    /// Sobrecarga que muestra las clases a las cuales asiste.
    /// </summary>
    /// <returns></returns>
    protected override string ParticiparEnClase()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("TOMA CLASES DE:{0}", this.clasesQueToma);
        return sb.ToString();
    }
    /// <summary>
    /// Sobrecarga ToString muestra los datos del alumno.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.MostrarDatos();
    }
    /// <summary>
    /// Sobrecarga para verificar si  un alumno asiaste a cierta clase.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="clases"></param>
    /// <returns></returns>
    public static bool operator ==(Alumno a, Universidad.EClases clases)
    {
        bool salida = false;
        if (a.clasesQueToma == clases && a.estadoCuneta != EEstadoCuenta.Deudor)
        {
            salida = true;
        }
        return salida;
    }
    /// <summary>
    /// Retornara true cuando el alumno no tome esa clase ni tenga la cuota paga.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="clases"></param>
    /// <returns></returns>
    public static bool operator !=(Alumno a, Universidad.EClases clases)
    {
        return a.clasesQueToma != clases;
    }




    #endregion

}
