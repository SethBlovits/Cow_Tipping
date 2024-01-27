using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tippingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool tipping;
    public Animator m_animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tipping){
            m_animator.SetBool("isTipping",true);
        }
        else{
            m_animator.SetBool("isTipping", false);
        }
    }
}
