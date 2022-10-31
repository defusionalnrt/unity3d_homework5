using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundController : MonoBehaviour{
    public actionManager actionmanager;
    public diskFactory diskfactory;
    public totalGUI totalgui;
    public scoreController scorecontroller;
    float time;
    int diskCount;
    int subRoundCount;
    bool gameStart;
    int roundCount;

    // Start is called before the first frame update
    public void Start(){
        time = 0f;
        roundCount = 1;
        diskCount = 4;
        subRoundCount = 0;
        gameStart = false;
        actionmanager = singleton<actionManager>.Instance;
        diskfactory = singleton<diskFactory>.Instance;
        totalgui = singleton<totalGUI>.Instance;
        scorecontroller = singleton<scoreController>.Instance;
        scorecontroller.setScore();
    }
    public int getRound(){
        return roundCount;
    }
    public int getDiskCount(){
        return diskCount;
    }
    public void startGame(){
        Debug.Log("rc.startGame");
        gameStart = true;
    }
    // Update is called once per frame
    void Update(){
        Debug.Log("start game");
        if(!gameStart){
            Debug.Log("not start game");
            return;
        }
        time += Time.deltaTime;
        if(roundCount > 6){
            gameStart = false;
            return;
        }
        if(subRoundCount > 10){
            subRoundCount = 0;
            ++roundCount;
            diskCount += roundCount;
        }
        if(time > 2.5f - roundCount * 0.15f){
            time = 0f;
            ++subRoundCount;
            for(int i = 0;i < diskCount;++i){
                GameObject disk = diskfactory.getWaitingDisk((int)Random.Range(1,4));
                disk.transform.position = new Vector3(0,0,0);
                disk.SetActive(true);
                actionmanager.fly(disk);
            }
        }
    }
    public void updateScore(diskData diskD){
        scorecontroller.addScore(diskD);
    }
    public void Reset() {
        scorecontroller.setScore();
        time = 0f;
        roundCount = 1;
        diskCount = 4;
        gameStart = false;
        subRoundCount = 0;
    }

}
