using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Describe al personaje principal del juego
/// </summary>
public class Personaje : MonoBehaviour
{    
    #region "Enums"

    public enum E_Direcciones
    {
        Reposo,
        Este,
        Oeste,
        Arriba,
        Abajo
    }

    #endregion

    #region "Atributos"

    public E_Direcciones DireccionActual { get; set; }

    public Vector3 Velocidad { get; set; }

    public bool Saltando { get; set; }

    public DateTime TiempoUltimaActualizacion { get; set; }

    public static float TraslacionX { get; set; }

    public static int Vidas = 5;

    public float PosicionInicialY { get; set; }

    public bool SaltandoDeTrampolin { get; set; }

    public static int Puntuacion = 0;

    public static double Tiempo = 0;

    public static int TiempoAntesMorir = 0;

    #endregion

    #region "Comportamientos"

    /// <summary>
    /// Desplaza al personaje en X con respecto a la tecla presionada
    /// </summary>
    public void DesplazarseX(bool auto = false)
    {
        if (auto)
            TraslacionX = Velocidad.x;
        else
            TraslacionX = Input.GetAxis("Horizontal") * Velocidad.x;

        if (TraslacionX > 0)
            DireccionActual = E_Direcciones.Este;
        if (TraslacionX < 0)
            DireccionActual = E_Direcciones.Oeste;

        TraslacionX *= Time.deltaTime;
        transform.Translate(TraslacionX, 0, 0);
    }

    /// <summary>
    /// Lee la tecla para saltar, impide saltar si ya se esta saltando
    /// </summary>
    public void EmpezarSalto()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && !Saltando)
            DireccionActual = E_Direcciones.Arriba;
    }

    /// <summary>
    /// Hace que el personaje salte
    /// </summary>
    public void Saltar()
    {
        if (DireccionActual == E_Direcciones.Arriba && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.04))
		{
			this.gameObject.GetComponent<Rigidbody2D>().velocity += Vector2.up * 6.8f;
            //transform.Translate(0, Velocidad.y, 0);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            Saltando = true;
            DireccionActual = E_Direcciones.Reposo;
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }

    public void MovimientoEnElAire()
    {
        if(SaltandoDeTrampolin)
        {
            TraslacionX = Input.GetAxis("Horizontal") * Velocidad.x;
            if (TraslacionX > 0)
                DireccionActual = E_Direcciones.Este;
            if (TraslacionX < 0)
                DireccionActual = E_Direcciones.Oeste;

            TraslacionX *= Time.deltaTime;
            transform.Translate(TraslacionX, 0, 0);
        }
    }

    #endregion
}
