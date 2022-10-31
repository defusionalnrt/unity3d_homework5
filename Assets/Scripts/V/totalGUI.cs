using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalGUI : MonoBehaviour{
    userAction useraction;
    string outputText;
    bool gameStart,gameFailed;
    // Start is called before the first frame update
    void Start(){
        useraction = director.GetSingleton().currentSceneController as userAction;
        gameStart = gameFailed = false;
        outputText = "Round 1    Score: 0";

    }
    public void updateText(int round,int score){
        if(round <= 5){
            outputText = "Round " + round + "   Score: " + score;
        }
        else{
            outputText = "Final Score: " + score;
            gameFailed = true;
        }
        
    }

    public void Reset() {
        gameStart = gameFailed = false;
        outputText = "round1:   score:0";
    }
    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI(){
        GUIStyle curGUI = new GUIStyle();
        if(!gameStart){
            curGUI.normal.textColor = Color.white;
            curGUI.fontSize = 30;
            curGUI.alignment = TextAnchor.MiddleCenter;
            if(GUI.Button(new Rect(30, 30, Screen.width - 60, Screen.height - 60), "点击开始", curGUI)) {
                Debug.Log("clicked");
                useraction.startGame();
                gameStart = true;
                gameFailed = false;
            }
        }
        else{
            curGUI.normal.textColor = Color.white;
            curGUI.fontSize = 20;
            curGUI.alignment = TextAnchor.MiddleCenter;
            GUI.Button(new Rect(30, 10, Screen.width - 60, 50), outputText, curGUI);
            if (!gameFailed && Input.GetButtonDown("Fire1")){
                useraction.hit(Input.mousePosition);
            }
        }
        if(gameFailed == true && gameStart == true){
            GUIStyle ggStyle = new GUIStyle();
            ggStyle.normal.textColor = Color.white;
            ggStyle.fontSize = 30;
            ggStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Button(new Rect(30, 30, Screen.width - 60, Screen.height - 60), "游戏结束", ggStyle);
        }

    }
}
