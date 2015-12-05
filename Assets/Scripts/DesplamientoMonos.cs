using UnityEngine;
using System.Collections;
using System;

public class DesplamientoMonos : Personaje {


    public bool MoverseAutomaticamente { get; set; }
    public TimeSpan TiempoMoverseAuto { get; set; }
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
            DesplazamientoMono();


        if (UltimoCheckpointPersonaje != Desplazamiento.CheckPoint)
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
        if (colisionado.name.Contains("Personaje"))
        {
            Velocidad = colisionado.GetComponent<Desplazamiento>().Velocidad;
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

        }
    }

    /// <summary>
    /// Desplaza automaticamente la rueda hacia la dirección dada
    /// </summary>
    public void DesplazamientoMono()
    {
       // while (DireccionActual == E_Direcciones.Este && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        //
            //transform.Translate(Velocidad.x, 0, 0);
          //  TiempoUltimaActualizacion = DateTime.Now;
        //}

        while (DireccionActual == E_Direcciones.Oeste && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            transform.Translate(-Velocidad.x, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }
}
