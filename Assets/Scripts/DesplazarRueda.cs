﻿using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Describe el desplazamiento de las ruedas y las interrupciones que pueden encontrar en su trayecto
/// </summary>
public class DesplazarRueda : Personaje
{
    public bool PersonajeEncima { get; set; }
    public bool MoverseAutomaticamente { get; set; }
    public TimeSpan TiempoMoverseAuto { get; set; }
    public bool Choco { get; set; }
    public Vector3 UltimoCheckpointPersonaje { get; set; }
    public Vector3 CheckPoint { get; set; }
    public bool ResetRequestCompletado { get; set; }
    void Awake()
    {
        Velocidad = new Vector3(0.2f, 0);
        DireccionActual = E_Direcciones.Oeste;
        TiempoUltimaActualizacion = DateTime.Now;
        UltimoCheckpointPersonaje = Desplazamiento.CheckPoint;
        CheckPoint = transform.localPosition;
    }

    void Update()
    {
        if (!Desplazamiento.ResetRequestCompletado)
            ResetRequestCompletado = false;

        if (Enterrado && !ResetRequestCompletado)
        {
            transform.localPosition = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
            ResetRequestCompletado = true;
        }

        if (PersonajeEncima)
        {
            DesplazarseX();
            if (Enterrado)
            {
                Enterrado = false;
            }
        }
        else
            DesplazamientoRueda();

        if (Choco && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.2))
        {
            Choco = false;
            TiempoUltimaActualizacion = DateTime.Now;
        }

        if(UltimoCheckpointPersonaje != Desplazamiento.CheckPoint)
        {
            UltimoCheckpointPersonaje = Desplazamiento.CheckPoint;
            CheckPoint = transform.localPosition;
        }
    }

    /// <summary>
    /// Maneja las colisiones de las ruedas con respecto a \colisionado\
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó</param>
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Personaje") && !Choco)
        {
            Velocidad = colisionado.GetComponent<Desplazamiento>().Velocidad;
            PersonajeEncima = true;
        }
    }

    /// <summary>
    /// Maneja cuando la rueda deja de colisionar con \colisionado\
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó</param>
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

    /// <summary>
    /// Desplaza automaticamente la rueda hacia la dirección dada
    /// </summary>
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