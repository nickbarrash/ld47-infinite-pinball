using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    Transform ballTransform;

    // Start is called before the first frame update
    void Awake()
    {
        ballTransform = GameObject.Find("Pinball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, ballTransform.position.y, transform.position.z);
    }
}
