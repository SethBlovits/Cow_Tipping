using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float moveSpeed;

    //float currentMoveSpeedX=0;
    //float currentMoveSpeedY=0;
    Rigidbody m_rigidbody;
    public Animator m_animator;
    GameObject playerParent;
    public TMP_Text text;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        text.text = "Win by making 20 cows laugh so hard they tip over.WASD to move. Shift to sprint. Hold E next to a cow to start telling jokes. Farmers will shoot if you get too close. Don't get shot or you lose!";
        transform.eulerAngles = new Vector3(0,-180,0);
        //maxSpeed = runSpeed;
       // layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;
    }
   
    void buttonWatcher(){
        Vector3 moveVector = Vector3.zero;
        m_animator.SetBool("isMoving",false);
        if(Input.GetKey("left shift")){
            
            moveSpeed = 20;
        }
        else{
            moveSpeed = 15;
        }   
        if(Input.GetKey("a")){
            text.text = "";
            moveVector += -transform.right*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //currentMoveSpeedX=-speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position - transform.right * Time.deltaTime * speed);
        }
        if(Input.GetKey("d")){
            text.text = "";
            moveVector += transform.right*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedX=speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        if(Input.GetKey("w")){
            text.text = "";
            moveVector += transform.forward*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedY=speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
           // m_rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
        if(Input.GetKey("s")){
            text.text = "";
            moveVector += -transform.forward*Time.deltaTime*moveSpeed;
            //m_animator.SetBool("isMoving",true);
            //m_animator.SetTrigger("WalkTrigger");
            //currentMoveSpeedY=-speed;
            //m_animator.SetFloat("Speed%",currentMoveSpeed);
            //m_rigidbody.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
        }
        m_rigidbody.MovePosition(transform.position+moveVector);
        /*if(Input.GetKeyDown("space") && canJump){
            jumpBuffered = true;
        }*/
    }
    
    // Update is called once per frame
    /*
    void checkShift(){
        if(Input.GetKey("left shift")){
            speed = runSpeed;
        }
        else{
            speed = walkSpeed;
        }
    }
    */
    /*
    void checkSpeed(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //currentSpeed = m_rigidbody.velocity.magnitude;
        m_rigidbody.AddForce(transform.rotation * new Vector3(horizontal,0,vertical) * Time.deltaTime * speed,ForceMode.Impulse);
        float newSpeed = m_rigidbody.velocity.magnitude;
        if(newSpeed>=maxSpeed){
            m_rigidbody.AddForce(transform.rotation * -new Vector3(horizontal,0,vertical) * Time.deltaTime * speed,ForceMode.Impulse);
        }
    }
    */
    void FixedUpdate() {
        
        transform.eulerAngles = new Vector3(0,transform.rotation.eulerAngles.y,0);
        //currentMoveSpeedX = 0;
        //currentMoveSpeedY = 0;
       
        //checkShift();
        buttonWatcher();
        
        //m_animator.SetFloat("X_Speed",currentMoveSpeedX); 
        //m_animator.SetFloat("Y_Speed",currentMoveSpeedY);
        
        
    }
    /*
    void FixedUpdate(){
        
        checkSpeed();
        
        if(jumpBuffered && canJump){
            m_rigidbody.AddForce(transform.up*jumpheight,ForceMode.Impulse);
            jumpBuffered = false;
        }
        //m_rigidbody.AddForce(Vector3.down * gravity * m_rigidbody.mass);
        
    }
    
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Mountains"){
            canJump = true;
        }
    }
    void OnCollisionExit(Collision collision){
        if(collision.gameObject.name == "Mountains"){
            canJump = false;
        }
    }*/
}