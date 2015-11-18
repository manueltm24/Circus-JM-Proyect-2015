using UnityEngine;
using System.Collections;
using System;

public class BalancearseCuerdas : MonoBehaviour
{
    public DateTime TiempoUltimaActualizacion { get; set; }

    void Awake()
    {
        TiempoUltimaActualizacion = DateTime.Now;
    }

    void Update()
    {
        if (DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.3))
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
            TiempoUltimaActualizacion = DateTime.Now;
        }        
    }

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Personaje"))
        {
            Vector3 escala = colisionado.transform.localScale;
            escala.x *= -1;
            colisionado.transform.localScale = escala;
            colisionado.transform.Translate(transform.localScale.x/3, 0,0);
        }
    }
}
