﻿using UnityEngine;
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
        Application.LoadLevel(MainMenu_MoverCamara.Actual + 1);
    }
}
