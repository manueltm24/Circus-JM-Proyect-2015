using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContarTiempo : MonoBehaviour {

    public Text TextoTiempoActual { get; set; }

    void Start()
    {
        TextoTiempoActual = this.gameObject.GetComponent<Text>();
        TextoTiempoActual.text = Personaje.Tiempo + "s";
    }

    void Update()
    {
        //Si el mensaje de la puntuación esta desactualizado, lo actualiza
        if (Personaje.Tiempo + "s" != TextoTiempoActual.text)
            TextoTiempoActual.text = Personaje.Tiempo + "s";

    }
}
