using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicFly : ScriptableObject{
    public bool enable = true;
    public bool destroy = false;
    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    Vector3 speed;
    Vector3 F;
    public static physicFly GetPhysicFly(diskData diskdata){
        physicFly flySetup = ScriptableObject.CreateInstance<physicFly>();
        flySetup.F = diskdata.F;
        flySetup.speed = diskdata.speed;
        return flySetup;
    }
    // Start is called before the first frame update
    public void Start(){
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = speed;
        this.gameObject.GetComponent<ConstantForce>().force = F;
        this.gameObject.GetComponent<ConstantForce>().torque = new Vector3(0.2F,0,-0.2F);
    }

    // Update is called once per frame
    public void Update(){
        if(this.transform.position.y < -10){
            enable = false;
            destroy = true;
            topController controller = (topController)director.GetSingleton().currentSceneController;
            controller.diskfactory.toWaitingList(this.gameObject);
        }
    }
}
