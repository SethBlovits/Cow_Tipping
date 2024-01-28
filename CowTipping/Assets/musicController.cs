using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicPlayer;
    public bool chased = false;
    public AudioClip chaseSong;
    bool playOnce = true;

    // Update is called once per frame
    void Update()
    {
        if(chased & playOnce){
            musicPlayer.clip = chaseSong;
            musicPlayer.Play();
            playOnce = false;
        }
    }
}
