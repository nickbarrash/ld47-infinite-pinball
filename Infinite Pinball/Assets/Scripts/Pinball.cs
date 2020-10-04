using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public float speedCap;

    Rigidbody body;

    private void Awake() {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (body.velocity.magnitude > speedCap) {
            body.velocity = body.velocity.normalized * speedCap;
        }

        if (transform.position.z > 0) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                -0.6f
            );   
        }

        if (transform.position.z < -1) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                -0.6f
            );
        }
    }
}
