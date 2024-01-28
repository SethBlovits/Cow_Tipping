using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tippingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool tipping;
    public Animator m_animator;
    public AudioSource flipSound;
    bool playOnce = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tipping){
            m_animator.SetBool("isTipping",true);
            if(playOnce){
                flipSound.Play();
                playOnce = false;
            }
            
        }
        else{
            m_animator.SetBool("isTipping", false);
        }
    }
}
