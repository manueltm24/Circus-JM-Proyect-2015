using UnityEngine;
using System.Collections;
using System;

public class ColisionarRuedas : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Rueda") && colisionado != this.gameObject)
        {
            if (transform.parent.GetComponent<DesplazarRueda>().PersonajeEncima)
            {
                transform.parent.GetComponent<DesplazarRueda>().Choco = true;
                colisionado.transform.parent.GetComponent<DesplazarRueda>().Choco = true;
                colisionado.transform.parent.GetComponent<DesplazarRueda>().TiempoUltimaActualizacion = DateTime.Now;
            }

            transform.parent.GetComponent<DesplazarRueda>().TiempoUltimaActualizacion = DateTime.Now;
            transform.parent.GetComponent<DesplazarRueda>().PersonajeEncima = false;
            transform.parent.GetComponent<DesplazarRueda>().Velocidad = new Vector3(0.2f, 0);

            if (transform.parent.GetComponent<DesplazarRueda>().DireccionActual == Personaje.E_Direcciones.Oeste)
                transform.parent.GetComponent<DesplazarRueda>().DireccionActual = Personaje.E_Direcciones.Este;
            else
                transform.parent.GetComponent<DesplazarRueda>().DireccionActual = Personaje.E_Direcciones.Oeste;
        }
    }
}
