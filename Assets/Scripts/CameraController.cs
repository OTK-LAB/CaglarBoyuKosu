using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
public GameObject Player;
Vector3 offset;

private void Start(){
    offset = transform.position - Player.transform.position;
}

private void LateUpdate(){
    transform.position = Player.transform.position + offset;

}



}
