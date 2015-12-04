using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMenuActivar : MonoBehaviour {

    public Button BotonOpciones { get; set; }

    public Image ImagenBoton { get; set; }

    // Use this for initialization
    void Start()
    {
        BotonOpciones = this.gameObject.GetComponent<Button>();
        BotonOpciones.enabled = false;
        ImagenBoton = this.gameObject.GetComponent<Image>();
        ImagenBoton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Desplazamiento.Vidas <= 0)
        {
            BotonOpciones.enabled = true;
            ImagenBoton.enabled = true;
        }
    }
}
