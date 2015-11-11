using UnityEngine;
using System.Collections;
using System;

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

    #endregion

    #region "Comportamientos"

    public void DesplazarseX()
    {
        float translationX = Input.GetAxis("Horizontal") * Velocidad.x;
        translationX *= Time.deltaTime;
        transform.Translate(translationX, 0, 0);
    }

    public void EmpezarSalto()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && !Saltando)
            DireccionActual = E_Direcciones.Arriba;
    }

    public void Saltar()
    {
        if (DireccionActual == E_Direcciones.Arriba && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.04))
        {
            transform.Translate(0, Velocidad.y, 0);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.9f;
            Saltando = true;
            DireccionActual = E_Direcciones.Reposo;
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }

    #endregion
}
