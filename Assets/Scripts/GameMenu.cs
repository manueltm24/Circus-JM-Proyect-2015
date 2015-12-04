using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EjecutarOpciones(string opcion)
    {
        switch (opcion)
        {
            case "Repetir":
                Application.LoadLevel(Application.loadedLevel);
                break;
            case "Salir":
                Application.LoadLevel(0);
                break;
        }
    }
}
