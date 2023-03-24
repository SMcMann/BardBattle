using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScreen : MonoBehaviour
{
    public Transform Square;
    public Vector3 offset;
    public Vector3 birdeye;
    void Start()
    {
        transform.position = Square.position + offset;
    }

    // Update is called once per frame
   
}
