using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextBubble : MonoBehaviour
{
    // Start is called before the first frame update
    public bool bubbles=false;
    string[] cowLines;
    string[] Jokes;
    public int dialogueIndex=0;
    public TMP_Text text;
    float bubbleTimer=3f;
    public List<string> allLines;
    public Image mugshot;
    public Sprite cow;
    public Sprite player;
    void Start()
    {
        allLines = new List<string>();
        text.text = "Got Any Jokes?";
        shuffleLines();
    }
    void shuffleLines(){
        cowLines = new string[]{"Heh, nice one.",
        "You got some good jokes kid",
        "You make that up yourself?",
        "Don't let the old man hear that one.",
        "Moo",
        "Good one.",
        "I like that one.",
        "I might use that joke later.",
        "I like it.",
        "Moooo!"};
        Jokes = new string[]{"What do you call a cow with no legs? Ground beef!",
        "Why did the farmer give his cow a bell? Because he wanted to have a moo-sical farm!",
        "What do you call a cow with a sense of humor?Laughing stock!",
        "What did the farmer say after he told a joke to the cow? I think you herd me!",
        "Why did the cow go to space?To see the moooon!",
        "What do you get when you cross a cow and a trampoline? Milkshakes!",
        "How does a farmer mend his overalls? With a cabbage patch!",
        "Why did the farmer bring a ladder to the bar?Because he heard the drinks were on the house!",
        "What do you call a farmer who can't find his tractor?Out standing in his field!",
        "How do farmers party?They turnip the beet!"};
        for (int t = 0; t < Jokes.Length; t++ )
        {
            string tmp = Jokes[t];
            int r = Random.Range(t, Jokes.Length);
            Jokes[t] = Jokes[r];
            Jokes[r] = tmp;
        }
        for (int t = 0; t < cowLines.Length; t++ )
        {
            string tmp = cowLines[t];
            int r = Random.Range(t, cowLines.Length);
            cowLines[t] = cowLines[r];
            cowLines[r] = tmp;
        }
        //cowLines = new string[10];
        //allLines.Add("Got any jokes?");
        for(int i = 1; i<10; i++){
            allLines.Add(Jokes[i]);
            allLines.Add(cowLines[i]);   
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bubbles);
        bubbleTimer-=Time.deltaTime;
        if(bubbles){
            if(bubbleTimer<=0){
                Dialogue();
                bubbleTimer=3f;
            }
        }
        else{
            dialogueIndex = 0;
        }
    }


    void Dialogue(){
        if(mugshot.sprite.name=="cowmugshot"){
            mugshot.sprite = player;
        }
        else{
            mugshot.sprite=cow;
        }
        text.text = allLines[dialogueIndex];
        if(dialogueIndex<allLines.Count-1){
            dialogueIndex++;
        }
        else{
            dialogueIndex=0;
        }

    }
}
