using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

/// <summary>
/// Describe una actuación cirquense
/// </summary>
public class Actuacion : MonoBehaviour {

    #region "Atributos"

    public string Nombre { get; set; }

    public int PuntuacionMaxima { get; set; }

    public double TiempoRecord { get; set; }

    public string PuntuacionMaximaArchivo { get; set; }

    public string TiempoRecordArchivo { get; set; }

    #endregion

    #region "Constructores"

    public Actuacion()
    {

    }

    public Actuacion(string nombre, string puntuacionMaximaArchivo, string tiempoRecordArchivo)
    {
        Nombre = nombre;
        PuntuacionMaximaArchivo = puntuacionMaximaArchivo;
        TiempoRecordArchivo = tiempoRecordArchivo;
        PuntuacionMaxima = ObtenerPuntacion(puntuacionMaximaArchivo);
        TiempoRecord = ObtenerTiempoRecord(tiempoRecordArchivo);
    }

    #endregion

    #region "Comportamientos"

    /// <summary>
    /// Obtiene la puntuación maxima, descrita en el archivo: \nombreArchivo\
    /// </summary>
    /// <param name="nombreArchivo">Nombre del archivo donde se encuentra la puntuación maxima de esta actuación</param>
    /// <returns>Puntuación maxima obtenida en la actuación</returns>
    public int ObtenerPuntacion(string nombreArchivo)
    {
        int puntuacionMaxima;
        using (var fileStream = new FileStream(nombreArchivo + ".xml", FileMode.OpenOrCreate))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(int));

            try
            {
                var puntuacionCapturada = (int)serializer.ReadObject(fileStream);
                puntuacionMaxima = puntuacionCapturada; //Se obtiene la puntuación maxima registrada.
            }
            catch
            {
                //Si no existía antes el archivo, no habia puntuación maxima, por defecto 0.
                puntuacionMaxima = 0;
            }
        }

        return puntuacionMaxima;
    }

    /// <summary>
    /// Obtiene el tiempo record, descrito en el archivo: \nombreArchivo\
    /// </summary>
    /// <param name="nombreArchivo">Nombre del archivo donde se encuentra el tiempo record de esta actuación</param>
    /// <returns>Tiempo record obtenido en la actuación</returns>
    public double ObtenerTiempoRecord(string nombreArchivo)
    {
        double tiempoRecord;
        using (var fileStream = new FileStream(nombreArchivo + ".xml", FileMode.OpenOrCreate))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(double));

            try
            {
                var tiempoCapturado = (double)serializer.ReadObject(fileStream);
                tiempoRecord = tiempoCapturado; //Se obtiene el tiempo record registrado.
            }
            catch
            {
                //Si no existía antes el archivo, no habia tiempo record, por defecto 1000.
                tiempoRecord = 1000;
            }
        }

        return tiempoRecord;
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
                        new Actuacion("¡Los aros de fuego de la muerte!", "punt-aros", "tiempo-aros"),
                        new Actuacion("¡Las ruedas rodantes!", "punt-ruedas", "tiempo-ruedas"),
                        new Actuacion("¡El salto de cuerdas mortal!", "punt-balanceo-cuerda", "tiempo-balanceo-cuerda"),
                    };
            }
            return listaActuaciones;
        }

        set { listaActuaciones = value; }
    }

    #endregion
}
