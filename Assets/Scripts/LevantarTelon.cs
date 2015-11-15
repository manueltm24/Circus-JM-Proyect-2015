using UnityEngine;
using System.Collections;

/// <summary>
/// Describe las situaciones en que se carga una actuación seleccionada
/// </summary>
public class LevantarTelon : MonoBehaviour
{

	void Update () {
        if (Input.GetButton("Fire3") || Input.GetKey(KeyCode.Space))
        {
            CargarActuacion();
        }
	}

    /// <summary>
    /// Carga la actuación seleccionada
    /// </summary>
    public void CargarActuacion()
    {
        Application.LoadLevel(MainMenu_MoverCamara.Actual + 1);
    }
}
