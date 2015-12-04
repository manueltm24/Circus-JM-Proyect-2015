using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Define la utilización del KonamiCode y lo que sucede cuando se activa.
/// </summary>
public class KonamiCode : MonoBehaviour
{
    public AudioSource Audio { get; set; }

    public Image imagenKC { get; set; }

    public int Code { get; set; }

    public DateTime TiempoUltimaActualizacion { get; set; }

    public List<KeyCode> KonamiC { get; set; }

    public int Posicion { get; set; }

    void Start ()
    {
        imagenKC = GameObject.Find("IM_KonamiCode").GetComponent<Image>();
        imagenKC.enabled = false;
        TiempoUltimaActualizacion = DateTime.Now;
        KonamiC = new List<KeyCode>
        {
            KeyCode.UpArrow,
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.DownArrow,
            KeyCode.LeftArrow,
            KeyCode.RightArrow,
            KeyCode.LeftArrow,
            KeyCode.RightArrow,
            KeyCode.B,
            KeyCode.A
        };

        Audio = GameObject.Find(gameObject.name).GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        if (imagenKC.enabled == true)
            return;

        if (Posicion == KonamiC.Count && imagenKC.enabled == false)
        {
            imagenKC.enabled = true;
            Audio.Play();
            return;
        }

        if (Input.GetKeyDown(KonamiC[Posicion]) && imagenKC.enabled == false)
        {
            Posicion++;
            TiempoUltimaActualizacion = DateTime.Now;
        }
        else if(DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.7))
            Posicion = 0;
    }
}
