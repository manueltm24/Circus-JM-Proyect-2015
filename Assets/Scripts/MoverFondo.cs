using UnityEngine;
using System.Collections;

/// <summary>
/// Mueve el fondo
/// </summary>
public class MoverFondo : MonoBehaviour {

    public Vector3 Velocidad;

    public int Tipo;

    void Update()
    {
        //Movimiento horizontal
        if (Tipo == 0)
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * Velocidad.x) % 1, 0f);

        //Movimiento vertical
        if (Tipo == 1)
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, (Time.time * Velocidad.y) % 1);

        //Movimiento en dos direcciones
        if (Tipo == 2)
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * Velocidad.x) % 1, (Time.time * Velocidad.y) % 1);
    }
}
