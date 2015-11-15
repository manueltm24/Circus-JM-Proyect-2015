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

    void Start ()
    {
        TextoActual = 0;

        TextoNombre = GameObject.Find("Tx_NombreActuacion").GetComponent<Text>();
        TextoPuntuacionMaxima = GameObject.Find("Tx_Puntuacion").GetComponent<Text>();
        TextoTiempoRecord = GameObject.Find("Tx_TiempoRecord").GetComponent<Text>();

        TextoNombre.text = Actuacion.ListaActuaciones[0].Nombre;
        TextoPuntuacionMaxima.text = "Puntuacion Maxima: " + Actuacion.ListaActuaciones[0].PuntuacionMaxima.ToString();
        TextoTiempoRecord.text = "Tiempo Record: " + Actuacion.ListaActuaciones[0].TiempoRecord.ToString() + "s";
    }

	void Update ()
    {
        //Si los textos no son los correspondientes, se cambian
        if (TextoActual != MainMenu_MoverCamara.Actual)
        {
            TextoActual = MainMenu_MoverCamara.Actual;
            TextoNombre.text = Actuacion.ListaActuaciones[TextoActual].Nombre;
            TextoPuntuacionMaxima.text = "Puntuacion Maxima: " + Actuacion.ListaActuaciones[TextoActual].PuntuacionMaxima.ToString();
            TextoTiempoRecord.text = "Tiempo Record: " + Actuacion.ListaActuaciones[TextoActual].TiempoRecord.ToString() + "s";
        }
    }

    /// <summary>
    /// Guarda la puntuación maxima. ¡ESTO VA EN CADA ACTUACION, NO AQUI!
    /// </summary>
    private void XML_GuardarNuevaPuntuacionMaxima()
    {
        using (var fileStream = new FileStream("punt-aros.xml", FileMode.Create))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(int));
            serializer.WriteObject(fileStream, Actuacion.ListaActuaciones[0].PuntuacionMaxima);
        }
    }
}
