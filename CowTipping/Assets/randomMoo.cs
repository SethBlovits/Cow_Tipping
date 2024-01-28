using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMoo : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource moo;
    float timer;
    bool m_ToggleChange = true;
    bool m_Play = false;
    
    void Start()
    {
        timer = Random.Range(1,50);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<=0){
            m_Play = true;
            timer = Random.Range(1,50);
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
            Debug.Log("Playing Moo");
            //Play the audio you attach to the AudioSource component
            moo.Play();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
    }
}
