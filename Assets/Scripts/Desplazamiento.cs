using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

/// <summary>
/// Describe el desplazamiento del personaje principal y las interrupciones que puede encontrar en su trayecto
/// </summary>
public class Desplazamiento : Personaje
{
	public Transform Ganador;
	public Transform Muerto1;
	public int NivelActual;

	public Vector3 PosicionGuardada { get; set;}

	void Awake ()
    {

		NivelActual = Application.loadedLevel;
        Velocidad = new Vector3(4f, 2f);
        TiempoUltimaActualizacion = DateTime.Now;
        DireccionActual = E_Direcciones.Reposo;
        PosicionInicialY = transform.localPosition.y;
    }
	
	void Update ()
    {
        //Maneja la perdida de vidas del personaje al caer al suelo
        if(transform.localPosition.y < PosicionInicialY - 1f && Application.loadedLevel != 4)
        {
            Vidas--;
            Application.LoadLevel(Application.loadedLevel);
            return;
        }

        if (Application.loadedLevel != 4)
            DesplazarseX();
<<<<<<< HEAD
        else
            MovimientoEnElAire();

=======
	
>>>>>>> ManuelT
        EmpezarSalto();
        Saltar();
		CambioVelocidad();

	
	}

    /// <summary>
    /// Maneja las colisiones del personaje con respecto a \colisionado\
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó</param>
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
		if (colisionado.name.Contains("Suelo") || colisionado.name.Contains("Rueda") || colisionado.name.Contains("Final"))
        {
			if(Application.loadedLevel==1){
	            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
	            TiempoUltimaActualizacion = DateTime.Now;
				Saltando = false;
			}
        }

		if ((colisionado.name.Contains("Rueda") || colisionado.name.Contains("Final")))
		{
			if(Application.loadedLevel==3)
			{
				this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
				TiempoUltimaActualizacion = DateTime.Now;
				Saltando = false;
			}
		}
		if (colisionado.name.Contains("Aro"))
		{
			PosicionGuardada= transform.localPosition;
			Destroy(this.gameObject);
			Instantiate(Muerto1, new Vector3(PosicionGuardada.x,PosicionGuardada.y,PosicionGuardada.z), transform.rotation);
			Personaje.TraslacionX=0;
			Vidas--;
			Application.LoadLevel (NivelActual);

		}

		if (colisionado.name.Contains("Jarron"))
		{
			PosicionGuardada= transform.localPosition;
			Destroy(this.gameObject);
			Instantiate(Muerto1, new Vector3(PosicionGuardada.x,PosicionGuardada.y,PosicionGuardada.z), transform.rotation);
			Personaje.TraslacionX=0;
			Vidas--;
			Application.LoadLevel (NivelActual);

		}
		if (colisionado.name.Contains("Final"))
		{
			PosicionGuardada= transform.localPosition;
			Destroy(this.gameObject);
			Instantiate(Ganador, new Vector3(PosicionGuardada.x,PosicionGuardada.y,PosicionGuardada.z), transform.rotation);
			Personaje.TraslacionX=0;
		}

        if (colisionado.name.Contains("Cuerda") && SaltandoDeTrampolin)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
<<<<<<< HEAD
            DireccionActual = E_Direcciones.Reposo;
            SaltandoDeTrampolin = false;
            Saltando = false;
=======
			this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

>>>>>>> ManuelT
        }

        if (colisionado.name.Contains("Trampolin"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            TiempoUltimaActualizacion = DateTime.Now;
            Saltando = false;
            DireccionActual = E_Direcciones.Arriba;
            SaltandoDeTrampolin = true;
            Saltar();
        }

        if (colisionado.name.Contains("Barra"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
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

    /// <summary>
    /// Acelera al persnaje
    /// </summary>
	public void CambioVelocidad()
	{
		if (Input.GetKey(KeyCode.W))
			Velocidad = new Vector3(6f, 0);
		else
			Velocidad = new Vector3(4f, 0);
	}
}
