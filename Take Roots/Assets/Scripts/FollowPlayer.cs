using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform target;
    public float speed;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movementDir = new Vector3(transform.position.x - target.position.x, 0, 0);
        if(Mathf.Abs(transform.position.x - target.position.x) > 0)
        {
            transform.Translate(-Vector3.right * speed * movementDir.x, Space.World);
        }
    }
}
