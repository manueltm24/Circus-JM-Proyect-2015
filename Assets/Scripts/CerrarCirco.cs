using UnityEngine;
using System.Collections;

/// <summary>
/// Describe las situaciones en la que la aplicación se cierra
/// </summary>
public class CerrarCirco : MonoBehaviour {
    
	void Update ()
    {
        if (Input.GetButton("Fire2") || Input.GetKey(KeyCode.Escape))
        {
            TerminarFuncion();
        }
    }

    /// <summary>
    /// Cierra la aplicación
    /// </summary>
    public void TerminarFuncion()
    {
        Application.Quit();
    }
}
