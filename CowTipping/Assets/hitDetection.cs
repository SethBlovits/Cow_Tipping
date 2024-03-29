using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class hitDetection : MonoBehaviour
{
    public TMP_Text text;
    float resetTime = 3f;
    float timeScaler = 0;
    public AudioSource gameOverAudio;
    // Start is called before the first frame update
    void Start()
    {
        text.text="";
        timeScaler = 0;
    }
    // Update is called once per frame
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Bullet(Clone)"){
            text.text="Game Over! You got Caught";
            //transform.position = new Vector3(480,1,480);
            timeScaler = 1;
            gameOverAudio.Play();

        }
    }
    void Update(){
        resetTime -= Time.deltaTime * timeScaler;
        if(resetTime<=0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
