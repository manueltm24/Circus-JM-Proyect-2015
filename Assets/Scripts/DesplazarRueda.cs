using UnityEngine;
using System.Collections;
using System;

public class DesplazarRueda : Personaje
{
    public bool PersonajeEncima { get; set; }
    public bool MoverseAutomaticamente { get; set; }
    public TimeSpan TiempoMoverseAuto { get; set; }

    void Awake ()
    {
        Velocidad = new Vector3(0.2f, 0);
        DireccionActual = E_Direcciones.Oeste;
        TiempoUltimaActualizacion = DateTime.Now;
    }

	void Update ()
    {
        if(PersonajeEncima)
            DesplazarseX();
        else
            DesplazamientoRueda();
    }

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Personaje"))
        {
            Velocidad = new Vector3(4f, 0);
            PersonajeEncima = true;
        }

        if (colisionado.name.Contains("Rueda") && colisionado != this.gameObject)
        {
            PersonajeEncima = false;
            Velocidad = new Vector3(0.2f, 0);
            TiempoUltimaActualizacion = DateTime.Now;

            if (DireccionActual == E_Direcciones.Oeste)
                DireccionActual = E_Direcciones.Este;
            else
                DireccionActual = E_Direcciones.Oeste;
        }
    }

    public void OnTriggerExit2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Personaje"))
        {
            colisionado.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Velocidad = new Vector3(0.2f, 0);
            DireccionActual = E_Direcciones.Oeste;
            TiempoUltimaActualizacion = DateTime.Now;
            PersonajeEncima = false;
        }
    }

    public void DesplazamientoRueda()
    {
        while (DireccionActual == E_Direcciones.Este && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            transform.Translate(Velocidad.x, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }

        while (DireccionActual == E_Direcciones.Oeste && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            transform.Translate(-Velocidad.x, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }
}
