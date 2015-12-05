using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Mueve la camara para que siga al personaje
/// </summary>
public class MoverCamara : MonoBehaviour
{
    public Transform Yo;
    public Transform Yo2;

    void Update ()
    {
        if (Personaje.TraslacionX != 0)
            MovimientoCamara();


        if (DateTime.Now.Subtract(Personaje.TiempoMuerte) > TimeSpan.FromSeconds(0.3) && Personaje.ResetRequest)
        {
            Destroy(Personaje.Muerto.gameObject);
            Personaje.ResetRequest = false;
            Personaje.Enterrado = true;
        }

        if (!Desplazamiento.ResetRequestCompletado && Personaje.Enterrado)
        {
            Instantiate(Yo, Desplazamiento.CheckPoint, Yo.localRotation);
            Camera.main.transform.localPosition = new Vector3(Desplazamiento.CheckPoint.x + 4f, 0, -10);
            Desplazamiento.ResetRequestCompletado = true;

            if (Application.loadedLevelName.Contains("Trampolin")){
                Instantiate(Yo2, DesplazarLeon.CheckPoint, Yo2.localRotation);
                Camera.main.transform.localPosition = new Vector3(Desplazamiento.CheckPoint.x + 4f, 0, -10);
                Desplazamiento.ResetRequestCompletado = true;
            }
        }
    }

    /// <summary>
    /// Mueve la camara con respecto a que tanto se movió el personaje
    /// </summary>
    public void MovimientoCamara()
    {
        transform.Translate(Personaje.TraslacionX, 0, 0);
    }
}
