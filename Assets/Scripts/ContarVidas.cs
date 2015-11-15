using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Toma las vidas restantes del personaje y las muestra en pantalla
/// </summary>
public class ContarVidas : MonoBehaviour {

    public Text TextoVidasActuales { get; set; }

    void Start ()
    {
        TextoVidasActuales = this.gameObject.GetComponent<Text>();
        TextoVidasActuales.text = "x" + Personaje.Vidas;
    }

	void Update ()
    {
        //Si el mensaje de las vidas esta desactualizado, lo actualiza
	    if("x" + Personaje.Vidas != TextoVidasActuales.text)
            TextoVidasActuales.text = "x" + Personaje.Vidas;
	}
}
