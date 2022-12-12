using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 7f;
    public Rigidbody rigid;

    public LayerMask groundLayer;
    public float raycastDistance = 0.6f;
    
    private bool isGrounded;

    public void start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
            
    void FixedUpdate(){
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,10);
    }


    void Update(){
        if(Input.GetKey("a")){
            GetComponent<Rigidbody>().AddForce(-50, 0, 0, ForceMode.Force);
        }

        else if(Input.GetKey("d")){
            GetComponent<Rigidbody>().AddForce(50, 0, 0, ForceMode.Force);
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
            isGrounded = true;
        else
            isGrounded = false;

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
    
    
    

        

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag =="puan"){
            Destroy(other.gameObject);
        }

    }

}
