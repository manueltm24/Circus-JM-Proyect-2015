using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameWin : MonoBehaviour {

    public Image ImagenGameOver { get; set; }

    public DateTime TiempoTriunfo { get; set; }

    // Use this for initialization
    void Start()
    {

        ImagenGameOver = this.gameObject.GetComponent<Image>();
        ImagenGameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Desplazamiento.Gano)
        {
            ImagenGameOver.enabled = true;
            TiempoTriunfo = DateTime.Now;
        }

        if (Desplazamiento.Gano && DateTime.Now.Subtract(TiempoTriunfo) > TimeSpan.FromSeconds(0.8))
            Application.LoadLevel(0);
    }
}
