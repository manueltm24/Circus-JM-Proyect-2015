using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Describe las situaciones en que se carga una actuación seleccionada
/// </summary>
public class LevantarTelon : MonoBehaviour
{
    public static Dificultad DificultadActual { get; set; }
    public DateTime TiempoInicioCarga { get; set; }
    public bool HayQueCargar { get; set; }

    void Update () {

        if (HayQueCargar && DateTime.Now.Subtract(TiempoInicioCarga) > TimeSpan.FromSeconds(1.5))
        {
            CargarActuacion();
        }

        if (Input.GetButton("Fire3") || Input.GetKey(KeyCode.Space))
        {
            TiempoInicioCarga = DateTime.Now;
            HayQueCargar = true;
        }
	}

    /// <summary>
    /// Carga la actuación seleccionada
    /// </summary>
    public void CargarActuacion()
    {
        Application.LoadLevel(MainMenu_MoverCamara.Actual + 1);
    }
}
