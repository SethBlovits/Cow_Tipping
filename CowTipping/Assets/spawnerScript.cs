using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject cow;
    public GameObject farmer;
    public int numCows;
    public int numFarmers;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<numCows;i++){
            Quaternion spawnRotation = Quaternion.Euler(new Vector3(0,Random.Range(0,360),0));
            Instantiate(cow,new Vector3(Random.Range(50,300),1f,Random.Range(100,500)),spawnRotation);
        }
        for(int i = 0;i<numFarmers;i++){
            Quaternion spawnRotation = Quaternion.Euler(new Vector3(0,Random.Range(0,360),0));
            Instantiate(farmer,new Vector3(Random.Range(50,300),1f,Random.Range(100,500)),spawnRotation);
        }
        
    }

    // Update is called once per frame
   
}
