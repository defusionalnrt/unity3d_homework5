using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topController:MonoBehaviour,sceneController,userAction {
    public totalGUI totalgui;
    public diskFactory diskfactory;
    public roundController roundcontroller;
    public scoreController scorecontroller;
    void Start(){
        director.GetSingleton().currentSceneController = this;
        load();
    }
    public void load(){
        Debug.Log("Loading...");
        this.gameObject.AddComponent<totalGUI>();
        totalgui = singleton<totalGUI>.Instance;

        this.gameObject.AddComponent<diskFactory>();
        diskfactory = singleton<diskFactory>.Instance;

        this.gameObject.AddComponent<roundController>();
        roundcontroller = singleton<roundController>.Instance;

        this.gameObject.AddComponent<scoreController>();
        scorecontroller = singleton<scoreController>.Instance;

        this.gameObject.AddComponent<actionManager>();
    }
    void Update(){
    }

    public void hit(Vector3 direction){
        Ray ray = Camera.main.ScreenPointToRay(direction);
        var hits = Physics.RaycastAll(ray);
        foreach(var hit in hits){
            if(hit.collider.gameObject.GetComponent<diskData>() == null){
                continue;
            }
            GameObject disk = hit.collider.gameObject;
            roundcontroller.updateScore(disk.GetComponent<diskData>());
            diskfactory.toWaitingList(disk);
        }

        totalgui.updateText(roundcontroller.getRound(),roundcontroller.scorecontroller.getScore());
    }
    public void startGame(){
        Debug.Log("start game called");
        roundcontroller.startGame();
    }
}
