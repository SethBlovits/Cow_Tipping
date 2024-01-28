using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowfaceSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public bool launch = false;
    public GameObject cowLaugh;
    public GameObject cowSmile;
    public GameObject cowExplode;
    public Canvas canvas;
    public float force;
    float launchTimer = 1f;
    GameObject[] cows;
    // Update is called once per frame
    void Start(){
        cows = new GameObject[]{cowLaugh,cowSmile,cowExplode};
        
    }
    void Update()
    {
        launchTimer -= Time.deltaTime;
        if(launch & launchTimer<=0){
            GameObject cowClone = Instantiate(cows[Random.Range(0,3)],new Vector3(Random.Range(-511,511),-366,0),Quaternion.identity);
            cowClone.transform.SetParent(canvas.transform,false);
            cowClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * force;
            launchTimer=1f;
        }
    }
}
