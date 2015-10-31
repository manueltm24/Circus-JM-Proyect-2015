using UnityEngine;
using System.Collections;
using System;

public class CambiarActuacion : MonoBehaviour {
    public static int Movidos { get; set; }
    public static bool LetsMove { get; set; }
    public Vector3 PosicionInicio { get; set; }
    public DateTime TiempoUltimaActualizacion { get; set; }
    public static string Actual { get; set; }
    void Start ()
    {
        PosicionInicio = transform.localPosition;
        TiempoUltimaActualizacion = DateTime.Now;
    }

	void Update ()
    {
        MoverCamara();
	}

    public void MoverCamara()
    {
        if (transform.localPosition == Vector3.zero)
            Actual = this.name; 
        int ultimo = 3;
        float tecla = Input.GetAxis("Horizontal");
        if (tecla < 0)
            tecla = -1;
        if (tecla > 0)
            tecla = 1;

        if (tecla != 0 && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.3))
        {
            if (this.gameObject.name == "main-menu-actuacion" + ultimo.ToString() && transform.localPosition == Vector3.zero)            
                LetsMove = true;
            
            if (LetsMove && transform.localPosition != PosicionInicio)
            {
                transform.localPosition = PosicionInicio;
                TiempoUltimaActualizacion = DateTime.Now;
                Movidos++;
                return;
            }

            if (LetsMove && Movidos == ultimo)
            {
                LetsMove = false;
                Movidos = 0;
            }

            transform.Translate(tecla * 18.5f, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }
}
