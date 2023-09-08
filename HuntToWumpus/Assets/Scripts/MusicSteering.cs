using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSteering : MonoBehaviour
{
    public AudioSource AudioMusicMenu;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        AudioMusicMenu.volume = Constants.MusicVolume;
    }

}
