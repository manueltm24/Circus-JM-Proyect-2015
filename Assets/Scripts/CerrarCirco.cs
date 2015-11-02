using UnityEngine;
using System.Collections;

public class CerrarCirco : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire2") || Input.GetKey(KeyCode.Escape))
        {
            TerminarFuncion();
        }
    }

    public void TerminarFuncion()
    {
        Application.Quit();
    }
}
