using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    //saða sola dönüþ
    private int desiredLane = 1;//0:left 1:middle 2:right
    public float laneDistance = 4;//iki lane arasý uzaklýk

    //zýplama
    public float jumpForce;
    public float Gravity;

    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        //zýplama komutlarý
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        //saða sola dönme komutlarý
        if(Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            desiredLane++;
            if(desiredLane == 3 ) 
            { 
                desiredLane= 2;          
            }       
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.fixedDeltaTime);

    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void jump()
    {
        direction.y = jumpForce;
    }

}
