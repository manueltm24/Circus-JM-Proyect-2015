using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    public void MoverCamara(float tecla = 0)
    {
        EventSystem.current.SetSelectedGameObject(null, null);
        int ultimo = 3;

        if(tecla == 0)
            tecla = Input.GetAxis("Horizontal");

        //Estandariza los valores de las teclas a 0 y 1, porqué originalmente esto es float, y no funciona bien con (int)
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
