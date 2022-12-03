using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    void Update(){
        if(Input.GetKey("a")){
            GetComponent<Rigidbody>().AddForce(-50, 0, 0, ForceMode.Force);
        }

        else if(Input.GetKey("d")){
            GetComponent<Rigidbody>().AddForce(50, 0, 0, ForceMode.Force);
        }
    }
    
    
    void FixedUpdate(){
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-10);
    }

        

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag =="puan"){
            Destroy(other.gameObject);
        }

    }

}
