using UnityEngine;
using System.Collections;

public class LevantarTelon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CargarActuacion()
    {
        switch (CambiarActuacion.Actual)
        {
            case "main-menu-actuacion1":
                Application.LoadLevel(1);
                break;

            case "main-menu-actuacion2":
                Application.LoadLevel(2);
                break;

            case "main-menu-actuacion3":
                Application.LoadLevel(3);
                break;
        }
    }
}
