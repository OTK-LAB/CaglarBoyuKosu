using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    private bool followPlayer = true;
    private float timer = 0f;
    private float followDelay = 0.49f;

    private void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    private void LateUpdate()
    {
        if (followPlayer)
        {
            transform.position = Player.transform.position + offset;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= followDelay)
            {
                followPlayer = true;
                timer = 0f;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z + offset.z);
            }
        }
    }

    public void StopFollowingPlayer()
    {
        followPlayer = false;
    }
}
