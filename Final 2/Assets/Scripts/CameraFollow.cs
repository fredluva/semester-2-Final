using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float yoffset = 1f;
    public float xoffset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xoffset, target.position.y + yoffset, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime
            ); 
    }
}
