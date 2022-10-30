using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreController : MonoBehaviour
{
    private int score;
    // Start is called before the first frame update
    void Start(){
        score = 0;
        
    }
    public void addScore(diskData dis){
        score += dis.score;
    }
    public int getScore(){
        return score;
    }
    public void setScore(int newScore = 0){
        score = newScore;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
