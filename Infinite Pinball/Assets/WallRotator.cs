using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotator : MonoBehaviour
{
    public float speed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, speed);
    }
}
