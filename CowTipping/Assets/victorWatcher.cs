using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class victorWatcher : MonoBehaviour
{
    public int totalTips;
    public int winningTips;
    public TMP_Text text;
    public TMP_Text score;
    float resetTime = 3f;
    float timeScaler = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalTips=0;
        timeScaler = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: "+totalTips;
        resetTime -= Time.deltaTime * timeScaler;
        if(winningTips == totalTips){
            text.text = "Congratulations on Winning!";
            timeScaler = 1;
        }
        if(resetTime<=0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
