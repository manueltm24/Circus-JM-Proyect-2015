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
        /*if (DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.3))
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
            TiempoUltimaActualizacion = DateTime.Now;
        } */       
    }
}
