using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

public class Actuacion : MonoBehaviour {

    #region "Atributos"

    public string Nombre { get; set; }

    public int PuntuacionMaxima { get; set; }

    public float TiempoRecord { get; set; }

    #endregion

    #region "Constructores"

    public Actuacion()
    {

    }

    public Actuacion(string nombre, string puntuacionMaximaArchivo, string tiempoRecordArchivo)
    {
        Nombre = nombre;
        PuntuacionMaxima = ObtenerPuntacion(puntuacionMaximaArchivo);
        TiempoRecord = ObtenerTiempoRecord(tiempoRecordArchivo);
    }

    #endregion

    #region "Comportamientos"

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

    public float ObtenerTiempoRecord(string nombreArchivo)
    {
        float tiempoRecord;
        using (var fileStream = new FileStream(nombreArchivo + ".xml", FileMode.OpenOrCreate))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(float));

            try
            {
                var tiempoCapturado = (float)serializer.ReadObject(fileStream);
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
                        new Actuacion("¡La cuerda floja resbaladiza!", "punt-cuerda", "tiempo-cuerda"),
                        new Actuacion("¡Las ruedas rodantes!", "punt-ruedas", "tiempo-ruedas")
                    };
            }
            return listaActuaciones;
        }

        set { listaActuaciones = value; }

    }

    #endregion
}
