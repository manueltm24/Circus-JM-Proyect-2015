using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
/// <summary>
/// Clase que permite el movimiento de la camara para mostrar los distintos tipos de actuaciones.
/// </summary>
public class MainMenu_MoverCamara : MonoBehaviour {
    public DateTime TiempoUltimaActualizacion { get; set; }
    public static int Actual = 0;

    void Start ()
    {
        TiempoUltimaActualizacion = DateTime.Now;
    }	

	void Update ()
    {
        MoverCamara();
	}

    /// <summary>
    /// Mueve la camara en forma de "loop infinito", cuando llega al final de un lado va al comienzo del otro
    /// </summary>
    public void MoverCamara()
    {
        int ultimo = 3;
        float tecla = Input.GetAxis("Horizontal");
        if (tecla < 0)
            tecla = -1;
        if (tecla > 0)
            tecla = 1;

        if (tecla != 0 && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.3))
        {
            Actual += (int)tecla;

            if (transform.localPosition.x >= (ultimo - 1) * 18.5f && tecla == 1)
            {
                transform.localPosition = new Vector3(0, 0, -10);
                TiempoUltimaActualizacion = DateTime.Now;
                Actual = 0;
                return;
            }

            if(transform.localPosition.x == 0f && tecla == -1)
            {
                transform.localPosition = new Vector3((ultimo - 1) * 18.5f, 0, -10);
                TiempoUltimaActualizacion = DateTime.Now;
                Actual = ultimo - 1;
                return;
            }

            transform.Translate(18.5f * tecla, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }
}
