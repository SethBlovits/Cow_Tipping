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
    public GameObject textBubble;
    bool foundCow = false;
          
        
    
    // Update is called once per frame
    void Start(){
        textBubble.SetActive(false);
    }
    void Update()
    {   
        if(Input.GetKey("e") & jokeToggle){
            //SDebug.Log("Drawing");
            textBubble.SetActive(true);
            cowImageSpawner.GetComponent<cowfaceSpawner>().launch = true;
            textBubble.GetComponent<TextBubble>().bubbles = true;
            if(current<1){
                current +=.001f;
            }
        }
        else{
            if(current>0){
                current -= .001f;
            }
            cowImageSpawner.GetComponent<cowfaceSpawner>().launch = false;
            textBubble.GetComponent<TextBubble>().bubbles = false;
            textBubble.GetComponent<TextBubble>().dialogueIndex = 0;
            textBubble.GetComponent<TextBubble>().mugshot.sprite = textBubble.GetComponent<TextBubble>().cow;
            textBubble.GetComponent<TextBubble>().text.text = "Got any jokes?";
            textBubble.SetActive(false);
        }
        
        
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position+transform.forward, 5f);
        foreach (var hitCollider in hitColliders){
            Debug.Log(hitCollider.name);
            if(hitCollider.name == "cow"){
                jokeToggle = true;
                foundCow = true;
            }
            if(current>=1 & jokeToggle & hitCollider.name == "cow"){
                if(!hitCollider.gameObject.GetComponent<tippingScript>().tipping){
                    GetComponent<victorWatcher>().totalTips ++;
                }
                hitCollider.gameObject.GetComponent<tippingScript>().tipping = true;
                
            }
        }
        if(foundCow){
            foundCow=false;
        }
        else{
            jokeToggle = false;
        }
        
        
        image.fillAmount = current/max;

        
        



    
    }
}

