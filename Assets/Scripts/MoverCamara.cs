using UnityEngine;
using System.Collections;

public class MoverCamara : MonoBehaviour
{

	void Update ()
    {
        if (Personaje.TraslacionX != 0)
            MovimientoCamara();

	}

    public void MovimientoCamara()
    {
        transform.Translate(Personaje.TraslacionX, 0, 0);
    }
}
