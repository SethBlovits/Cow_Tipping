using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceLines : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource farmerSpeak;
    bool m_Play = false;
    bool m_ToggleChange = true;
    float timer;
    public List<AudioClip> voices;
    void Start()
    {
        timer = Random.Range(50,250);
    }

    // Update is called once per frame
    void Update()
    {   

        if(timer<=0){
            m_Play = true;
            timer = Random.Range(10,15);
        }
        else{
            m_Play = false;
            timer -= Time.deltaTime;
        }
        playSound();
        m_ToggleChange = true;

        
    }
    void playSound(){
        if (m_Play == true && m_ToggleChange == true)
        {
            Debug.Log("Playing Sound");
            farmerSpeak.clip = voices[Random.Range(0,4)];
            //Play the audio you attach to the AudioSource component
            farmerSpeak.Play();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
    }
}
