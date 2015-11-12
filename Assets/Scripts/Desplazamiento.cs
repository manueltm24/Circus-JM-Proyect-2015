using UnityEngine;
using System.Collections;
using System;

public class Desplazamiento : Personaje
{

	void Start ()
    {
        Velocidad = new Vector3(4f, 2f);
        TiempoUltimaActualizacion = DateTime.Now;
        DireccionActual = E_Direcciones.Reposo;
    }
	
	void Update ()
    {
        DesplazarseX();
        EmpezarSalto();
        Saltar();
	}

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
		if (colisionado.name.Contains("Suelo"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            TiempoUltimaActualizacion = DateTime.Now;
            Saltando = false;
        }

        if (colisionado.name.Contains("aro"))
        {
            Debug.Log("A");
        }
    }


    public void OnTriggerExit2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Suelo"))
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
