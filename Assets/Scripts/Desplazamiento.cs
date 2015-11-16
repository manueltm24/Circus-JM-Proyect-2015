using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Describe el desplazamiento del personaje principal y las interrupciones que puede encontrar en su trayecto
/// </summary>
public class Desplazamiento : Personaje
{

	void Awake ()
    {
        Velocidad = new Vector3(4f, 2f);
        TiempoUltimaActualizacion = DateTime.Now;
        DireccionActual = E_Direcciones.Reposo;
        PosicionInicialY = transform.localPosition.y;
    }
	
	void Update ()
    {
        //Maneja la perdida de vidas del personaje al caer al suelo
        if(transform.localPosition.y < PosicionInicialY - 1f)
        {
            Vidas--;
            Application.LoadLevel(Application.loadedLevel);
            return;
        }

        DesplazarseX();
        EmpezarSalto();
        Saltar();
	}

    /// <summary>
    /// Maneja las colisiones del personaje con respecto a \colisionado\
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó</param>
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
		if (colisionado.name.Contains("Suelo") || colisionado.name.Contains("Rueda") || colisionado.name.Contains("Final"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            TiempoUltimaActualizacion = DateTime.Now;
			Saltando = false;
        }

        if (colisionado.name.Contains("Aro"))
        {
            Debug.Log("A");
        }
    }

    /// <summary>
    /// Maneja cuando el personaje deja de colisionar con \colisionado\
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó</param>
    public void OnTriggerExit2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Suelo") || colisionado.name.Contains("Rueda"))
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
