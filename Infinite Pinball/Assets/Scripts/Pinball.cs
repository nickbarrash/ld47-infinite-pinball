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
    }
}
