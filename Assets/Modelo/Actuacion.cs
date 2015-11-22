using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

/// <summary>
/// Describe una actuación cirquense
/// </summary>
public class Actuacion : MonoBehaviour {

    #region "Enums"

    public enum E_TipoActuacion
    {
        Suelo,
        Techo
    }

    #endregion

    #region "Atributos"

    public string Nombre { get; set; }

    public string PuntuacionMaximaArchivo { get; set; }

    public string TiempoRecordArchivo { get; set; }

    public string Mapa { get; set; }

    public E_TipoActuacion Tipo { get; set; }

    #endregion

    #region "Constructores"

    public Actuacion()
    {

    }

    public Actuacion(string nombre, string puntuacionMaximaArchivo, string tiempoRecordArchivo, string mapa, E_TipoActuacion tipo)
    {
        Nombre = nombre;
        Mapa = mapa;
        Tipo = tipo;
        PuntuacionMaximaArchivo = puntuacionMaximaArchivo;
        TiempoRecordArchivo = tiempoRecordArchivo;
    }

    #endregion

    #region "Datos estaticos"

    /// <summary>
    /// Genera una pseudo-base de datos con las actuaciones actualmente existentes
    /// </summary>
    private static List<Actuacion> listaActuaciones = null;
    public static List<Actuacion> ListaActuaciones
    {
        get
        {
            if (listaActuaciones == null)
            {
                listaActuaciones = new List<Actuacion>
                    {
                        new Actuacion("¡Los aros de fuego de la muerte!", "punt-aros", "tiempo-aros", "mapa-aros", E_TipoActuacion.Suelo),
                        new Actuacion("¡Las ruedas rodantes!", "punt-ruedas", "tiempo-ruedas", "mapa-ruedas", E_TipoActuacion.Suelo),
                        new Actuacion("¡El salto de cuerdas mortal!", "punt-cuerdas", "tiempo-cuerdas", "mapa-cuerdas", E_TipoActuacion.Techo),
                    };
            }
            return listaActuaciones;
        }

        set { listaActuaciones = value; }
    }

    #endregion
}
