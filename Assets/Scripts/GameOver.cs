using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Image ImagenGameOver { get; set; }

    // Use this for initialization
    void Start()
    {
        ImagenGameOver = this.gameObject.GetComponent<Image>();
        ImagenGameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Desplazamiento.Vidas <= 0)
        {
            ImagenGameOver.enabled = true;
        }
    }
}
