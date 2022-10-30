using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class diskFactory : MonoBehaviour{
    
    public List<diskData> runningDiskList;
    public List<diskData> waitingDiskList;
    string[] prefabList = new string[3] {"Prefabs/YelloD", "Prefabs/GreenD", "Prefabs/BlueD"};
    void Start(){
        Debug.Log("dFac");
        runningDiskList = new List<diskData>();
        waitingDiskList = new List<diskData>();
    }
    
    public GameObject getWaitingDisk(int level){
        Debug.Log(level);
        Debug.Log("getDisk");
        GameObject targetDisk = null;
        bool find = false;
        for(int i = 0; i < waitingDiskList.Count; i++){
            if(waitingDiskList[i].level == level){
                targetDisk = waitingDiskList[i].gameObject;
                waitingDiskList.RemoveAt(i);
                find = true;
                break;
            }
        }
        
        if(!find){
            //加载资源
            Debug.Log(prefabList[level - 1]);
            Debug.Log(Resources.FindObjectsOfTypeAll(typeof(GameObject)));
            var reso =  Resources.Load(prefabList[level - 1]) as GameObject;
            // var reso = AssetDatabase.LoadAssetAtPath<GameObject>(Prefabs[level - 1]);
            Debug.Log(reso);
            //资源初始化
            targetDisk = GameObject.Instantiate<GameObject>(reso, Vector3.zero, Quaternion.identity);
            if(targetDisk != null){
                Debug.Log("succeed init");
            }
            targetDisk.AddComponent<diskData>();
            targetDisk.AddComponent<Rigidbody>();
            targetDisk.AddComponent<ConstantForce>();
        }
        Debug.Log("nn");
        if(targetDisk != null){
            
            diskData diskdata = targetDisk.GetComponent<diskData>();
            setDiskData(diskdata, level);
            runningDiskList.Add(diskdata);
        }

        return targetDisk;
    }
    public void toWaitingList(GameObject disk){
        foreach(diskData disks in runningDiskList){
            if(disks.gameObject.GetInstanceID() == disk.GetInstanceID()){
                disk.SetActive(false);
                runningDiskList.Remove(disks);
                waitingDiskList.Add(disks);
                break;
            }
        }
    }

    public void setDiskData(diskData diskData, int level){
        if(level <= 1){
            diskData.level = 1;
            diskData.m = 1F + Random.Range(-0.5F, 0.5F);
            diskData.score = 50;
            diskData.speed = new Vector3(Random.Range(-0.1F, 0.1F), Random.Range(-0.1F, 0.1F), Random.Range(-0.1F, 0.1F));
            diskData.F = new Vector3(Random.Range(-1F, 1F), Random.Range(-1F, 1F), Random.Range(-1F, 1F));
        }
        else if(level == 2){
            diskData.level = 2;
            diskData.m = 2F + Random.Range(-1F, 1F);
            diskData.score = 100;
            diskData.speed = new Vector3(Random.Range(-2F, 2F), Random.Range(-2F, 2F), Random.Range(-2F, 2F));
            diskData.F = new Vector3(Random.Range(-2F, 2F), Random.Range(-2F, 2F), Random.Range(-2F, 2F));
        }
        else if(level == 3){
            diskData.level = 3;
            diskData.m = 3F + Random.Range(-1F, 1F);
            diskData.score = 300;
            diskData.speed = new Vector3(Random.Range(-5F, 5F), Random.Range(-5F, 5F), Random.Range(-5F, 5F));
            diskData.F = new Vector3(Random.Range(-5F, 5F), Random.Range(-5F, 5F), Random.Range(-5F, 5F));

        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
