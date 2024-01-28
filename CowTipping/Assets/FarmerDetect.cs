using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerDetect : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public farmerControl idleScript;
    public GameObject bullet;
    public GameObject shotgun;
    public GameObject farmerParent;
    float gunCooldown = 2f;
    Vector3 playerLocation;
    float visionRange = 10;
    public Animator m_animator;
    public Vector3[] patrolPoints;
    int currentPatrol = 0;
    bool alerted=false;
    void Start(){
        idleScript = GetComponent<farmerControl>();
        patrolPoints = new Vector3[3];
        for(int i = 0;i<3;i++){
            patrolPoints[i]= new Vector3(Random.Range(100,500),0,Random.Range(100,500));
        }

    }
    void Update()
    {
        farmerParent.transform.position = new Vector3(farmerParent.transform.position.x,1.71f,farmerParent.transform.position.z);
        if(alerted){
            Patrol();
        }
        gunCooldown-=Time.deltaTime;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, visionRange);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.name =="cow"){
                if(hitCollider.gameObject.GetComponent<tippingScript>().tipping){
                    heardLaughing();
                }
            }
            if(hitCollider.name == "Player"){
                    
                    farmerParent.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,hitCollider.transform.position-transform.position,2f,2f));
                    playerLocation = hitCollider.transform.position-shotgun.transform.position+shotgun.transform.forward;

                    //Debug.Log(hitCollider.transform.position);
                    seenPlayer();
                    //Debug.Log(playerLocation.magnitude);
                    if(playerLocation.magnitude>5f){
                        farmerParent.transform.position += farmerParent.transform.forward*Time.deltaTime*10;
                    }
                    
                }
        }
        if(gunCooldown<=0){
            gunCooldown = 2;
        }
       
    }
    void Patrol(){
        Debug.Log(patrolPoints[0]);
        float distance = Vector3.Magnitude(patrolPoints[currentPatrol]-farmerParent.transform.position);
        if(distance<5f)
        {
            if(currentPatrol<2){
                currentPatrol++;
            }
            else{
                currentPatrol=0;
            }
        }
        farmerParent.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,patrolPoints[currentPatrol]-transform.position,2f,2f));
        farmerParent.transform.position += farmerParent.transform.forward*Time.deltaTime*5; 
    }
    void heardLaughing(){
        alerted = true;
        m_animator.SetBool("isChasing",true);
        GetComponent<farmerControl>().idle=false;
        Debug.Log("Heard Laughing");
        visionRange = 30f;
        
    }
    void seenPlayer(){
        alerted = true;
        m_animator.SetBool("isChasing",true);
        visionRange = 30f;
        GetComponent<farmerControl>().idle=false;
        //Debug.Log("Seen Player");
        if(gunCooldown<=0){
            GameObject bulletClone = Instantiate(bullet,shotgun.transform.position+shotgun.transform.forward,farmerParent.transform.rotation);
            //GameObject bulletClone = Instantiate(bullet,shotgun.transform.position+shotgun.transform.forward,);
            bulletClone.GetComponent<Rigidbody>().velocity = playerLocation * 10;
        }
       
        

    }
    void attackPlayer(){
        idleScript.idle = false;
        GameObject bulletClone = Instantiate(bullet,shotgun.transform.position+shotgun.transform.forward,shotgun.transform.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(shotgun.transform.forward * 1000);

    }
}
