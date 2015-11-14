using UnityEngine;
using System.Collections;

public class DesplazarRueda : Personaje
{
    public bool PersonajeEncima { get; set; }

    void Start ()
    {
        Velocidad = new Vector3(4f, 0);
    }

	void Update ()
    {
        if(PersonajeEncima)
            DesplazarseX();
    }

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if(colisionado.name == "PF_Personaje(Clone)")
            PersonajeEncima = true;
    }

    public void OnTriggerExit2D(Collider2D colisionado)
    {
        if (colisionado.name == "PF_Personaje(Clone)")
            PersonajeEncima = false;
    }
}
