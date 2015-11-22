using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Serialization;
using System.IO;

/// <summary>
/// Muestra en el menú principal la información de la actuación seleccionada
/// </summary>
public class CambiarTextoActuacion : MonoBehaviour {

    public Text TextoNombre { get; set; }
    public Text TextoPuntuacionMaxima { get; set; }
    public Text TextoTiempoRecord { get; set; }
    public int TextoActual { get; set; }
    public static int PuntuacionMaxima { get; set; }
    public static double TiempoRecord { get; set; }
    public Dificultad DificultadActual { get; set; }

    void Start()
    {
        TextoActual = 0;

        TextoNombre = GameObject.Find("Tx_NombreActuacion").GetComponent<Text>();
        TextoPuntuacionMaxima = GameObject.Find("Tx_Puntuacion").GetComponent<Text>();
        TextoTiempoRecord = GameObject.Find("Tx_TiempoRecord").GetComponent<Text>();

        TextoNombre.text = Actuacion.ListaActuaciones[0].Nombre;

        PuntuacionMaxima = ObtenerPuntacion(Actuacion.ListaActuaciones[0].PuntuacionMaximaArchivo);
        TiempoRecord = ObtenerTiempoRecord(Actuacion.ListaActuaciones[0].TiempoRecordArchivo);

        TextoPuntuacionMaxima.text = "Puntuacion Maxima: " + ObtenerPuntacion(Actuacion.ListaActuaciones[0].PuntuacionMaximaArchivo);
        TextoTiempoRecord.text = "Tiempo Record: " + ObtenerTiempoRecord(Actuacion.ListaActuaciones[0].TiempoRecordArchivo);

        DificultadActual = Dificultad.ListaDificultades[0];
    }

	void Update ()
    {
        //Si los textos no son los correspondientes, se cambian
        if (TextoActual != MainMenu_MoverCamara.Actual || DificultadActual.Nombre != LevantarTelon.DificultadActual.Nombre)
        {
            DificultadActual = LevantarTelon.DificultadActual;

            TextoActual = MainMenu_MoverCamara.Actual;
            TextoNombre.text = Actuacion.ListaActuaciones[TextoActual].Nombre;

            PuntuacionMaxima = ObtenerPuntacion(Actuacion.ListaActuaciones[TextoActual].PuntuacionMaximaArchivo);
            TiempoRecord = ObtenerTiempoRecord(Actuacion.ListaActuaciones[TextoActual].TiempoRecordArchivo);

            TextoPuntuacionMaxima.text = "Puntuacion Maxima: " + PuntuacionMaxima.ToString();
            TextoTiempoRecord.text = "Tiempo Record: " + TiempoRecord.ToString();
        }
    }
    
    /// <summary>
    /// Obtiene la puntuación maxima, descrita en el archivo: \nombreArchivo\
    /// </summary>
    /// <param name="nombreArchivo">Nombre del archivo donde se encuentra la puntuación maxima de esta actuación</param>
    /// <returns>Puntuación maxima obtenida en la actuación</returns>
    public int ObtenerPuntacion(string nombreArchivo)
    {
        int puntuacionMaxima;
        using (var fileStream = new FileStream(nombreArchivo + LevantarTelon.DificultadActual.Sufijo + ".xml", FileMode.OpenOrCreate))
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
        using (var fileStream = new FileStream(nombreArchivo + LevantarTelon.DificultadActual.Sufijo + ".xml", FileMode.OpenOrCreate))
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
}
