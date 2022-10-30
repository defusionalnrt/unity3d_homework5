using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionRunner : MonoBehaviour{
    // Start is called before the first frame update
    private Dictionary<int, physicFly> flyDict = new Dictionary<int, physicFly>();
    private List<physicFly> waitingFlyQueue = new List<physicFly>();
    private List<int> destroyList = new List<int>();
    // Update is called once per frame
    void Update(){
        Debug.Log(waitingFlyQueue.Count);
        if(waitingFlyQueue.Count != 0){
            foreach (physicFly fly in waitingFlyQueue){
                flyDict[fly.GetInstanceID()] = fly;
            }
        }
        waitingFlyQueue.Clear();
        if(flyDict.Count != 0){
            foreach (var p in flyDict){
                if(p.Value.destroy){
                    destroyList.Add(p.Value.GetInstanceID());
                }
                else if(p.Value.enable){
                    p.Value.Update();
                }
            }
        }
        if(destroyList.Count != 0){
            foreach (int key in destroyList){
                var flyAct = flyDict[key];
                flyDict.Remove(key);
                Destroy(flyAct);
            }
        }
    }
    public void doAction(GameObject gameObject, physicFly flyAction){
        Debug.Log("doAction");
        flyAction.gameObject = gameObject;
        flyAction.transform = gameObject.transform;
        waitingFlyQueue.Add(flyAction);
        flyAction.Start();
    }
}
