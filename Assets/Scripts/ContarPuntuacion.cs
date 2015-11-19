using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Toma la puntuación actual del personaje y la muestra en pantalla
/// </summary>
public class ContarPuntuacion : MonoBehaviour {

    public Text TextoPuntuacionActual { get; set; }

    void Start ()
    {
        TextoPuntuacionActual = this.gameObject.GetComponent<Text>();
        TextoPuntuacionActual.text = "Puntuación: " + Personaje.Puntuacion;
    }

	void Update ()
    {
        //Si el mensaje de la puntuación esta desactualizado, lo actualiza
        if ("Puntuación: " + Personaje.Puntuacion != TextoPuntuacionActual.text)
            TextoPuntuacionActual.text = "Puntuación: " + Personaje.Puntuacion;

    }
}
