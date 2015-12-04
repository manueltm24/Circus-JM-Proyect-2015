using UnityEngine;
using System.Collections;

public class Sonar : MonoBehaviour {

    public AudioSource Audio { get; set; }
    public KeyCode Tecla;

    void Start ()
    {
        Audio = GameObject.Find(gameObject.name).GetComponent<AudioSource>();
    }

    void Update()
    {
        HacerSonido();
    }

    public void HacerSonido()
    {
        if(Input.GetKeyDown(Tecla))
            Audio.Play();
    }
}
