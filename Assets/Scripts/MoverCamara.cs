using UnityEngine;
using System.Collections;

/// <summary>
/// Mueve la camara para que siga al personaje
/// </summary>
public class MoverCamara : MonoBehaviour
{

	void Update ()
    {
        if (Personaje.TraslacionX != 0)
            MovimientoCamara();

	}

    /// <summary>
    /// Mueve la camara con respecto a que tanto se movió el personaje
    /// </summary>
    public void MovimientoCamara()
    {
        transform.Translate(Personaje.TraslacionX, 0, 0);
    }
}
