using UnityEngine;
using System.Collections;

public class SonidosColisionados : MonoBehaviour {

    public AudioSource Audio { get; set; }

    void Start ()
    {
        Audio = GameObject.Find(gameObject.name).GetComponent<AudioSource>();
        Audio.Play();
    }
}
