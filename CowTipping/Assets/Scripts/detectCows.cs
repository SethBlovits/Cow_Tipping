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

