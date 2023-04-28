using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FınıshLine : MonoBehaviour
{
    public bool isFinished = false;

    IEnumerator FreezeRotation(PlayerController player) //karakteri durduran kod
    {
        yield return new WaitForSeconds(5f);
        player.rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isFinished = true;
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                 StartCoroutine(FreezeRotation(player));
            }
        }
    }


}
