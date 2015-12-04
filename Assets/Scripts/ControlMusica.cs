using UnityEngine;
using System.Collections;

public class ControlMusica : MonoBehaviour
{
	public void MusicaOnOff()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.volume = 1;
            AudioListener.pause = false;
        }
    }
}
