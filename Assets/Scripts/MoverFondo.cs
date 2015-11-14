using UnityEngine;
using System.Collections;

public class MoverFondo : MonoBehaviour {

    public Vector3 Velocidad;

    public int Tipo;

    void Update()
    {
        if (Tipo == 0)
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * Velocidad.x) % 1, 0f);

        if (Tipo == 1)
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, (Time.time * Velocidad.y) % 1);

        if (Tipo == 2)
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * Velocidad.x) % 1, (Time.time * Velocidad.y) % 1);
    }
}
