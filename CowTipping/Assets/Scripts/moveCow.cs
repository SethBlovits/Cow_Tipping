using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCow : MonoBehaviour
{
    public GameObject cow;
    cowBehavior cowScript;
    // Start is called before the first frame update
    void Start()
    {
        cowBehavior cowScript = cow.GetComponent<cowBehavior>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(cow.GetComponent<cowBehavior>().moveTime){
            transform.position += transform.forward*Time.deltaTime;
            cow.GetComponent<cowBehavior>().moveTime = false;
        }
        
    }
}
