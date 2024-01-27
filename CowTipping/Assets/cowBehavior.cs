using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowBehavior : MonoBehaviour
{
   public GameObject cowParent;
    public Animator m_animator;
    // Start is called before the first frame update
    //public Rigidbody m_rigidBody;
    float randomTimer;
    bool reset = true; 
    bool complete = false;
    public bool moveTime = false;
    // Update is called once per frame
    void Start(){
        randomTimer =  Random.Range(2f,6f);
        m_animator.SetBool("isMoving",false);
    }
    void FixedUpdate()
    {
        
        //cowParent.transform.position += cowParent.transform.forward*.05f;
        //m_rigidBody.MovePosition(transform.position + transform.forward*Time.deltaTime);
        if(randomTimer <= 0){
            //randomRotation();
            //moveForward();
            m_animator.SetBool("isMoving",true);
            randomTimer =  Random.Range(2f,6f);
             
        }
        else{
            randomTimer -= Time.deltaTime;
            
            
        }
    }
    
    
    void moveForward(){
        //Debug.Log(randomTimer);
        //Debug.Log(cowParent.transform.forward);
        cowParent.transform.position += cowParent.transform.forward*Time.deltaTime*100;
        
    }
    void randomRotation(){
        cowParent.transform.eulerAngles = new Vector3(0, Random.Range(0,360),0);
    }
    void hopComplete(){
        
        
        m_animator.SetBool("isMoving",false);

    }
}
