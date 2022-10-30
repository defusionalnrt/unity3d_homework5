using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionManager:actionRunner{
    topController controller;
    physicFly physicflySetup;
    private void Start() {
        controller = (topController)director.GetSingleton().currentSceneController;
    }
    public void fly(GameObject flyingDisk){
        physicflySetup = physicFly.GetPhysicFly(flyingDisk.GetComponent<diskData>());
        doAction(flyingDisk,physicflySetup);
    }
    
}
