using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class detectCows : MonoBehaviour 
{
    // Start is called before the first frame update
    bool jokeToggle = false;
    //public Camera cam;
    public Image image;
    float current = 0f;
    float max = 1f;
    public GameObject cowImageSpawner;
          
        
    
    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKey("e") & jokeToggle){
            //SDebug.Log("Drawing");
            cowImageSpawner.GetComponent<cowfaceSpawner>().launch = true;
            if(current<1){
                current +=.001f;
            }
        }
        else{
            if(current>0){
                current -= .001f;
            }
            cowImageSpawner.GetComponent<cowfaceSpawner>().launch = false;
        }
        
        
        RaycastHit hit;

        if(Physics.SphereCast(transform.position,1,transform.forward,out hit,2)){
            //Debug.Log(hit.collider.name == "cow");
            if(hit.collider.name == "cow"){
                jokeToggle = true;
            }
            else{
                jokeToggle = false;
            }
            if(current>=1 & jokeToggle){
                hit.collider.gameObject.GetComponent<tippingScript>().tipping = true;
            }
        }
        image.fillAmount = current/max;

        
        



    
    }
}

