using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SeleccionarDificultad : MonoBehaviour {

    public Dropdown Drop { get; set; }

    void Start ()
    {
        Drop = GameObject.Find("Dd_Dificultades").GetComponent<Dropdown>();
        CambiarDificultad();
    }

    /// <summary>
    /// Asigna la dificultad seleccionada al telón, para saber en que modo se mostrará la actuación seleccionada
    /// </summary>
    public void CambiarDificultad()
    {
        LevantarTelon.DificultadActual = Dificultad.ListaDificultades[Drop.value];
    }
}
