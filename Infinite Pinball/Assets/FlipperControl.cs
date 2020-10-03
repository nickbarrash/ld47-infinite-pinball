using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    HingeJoint hinge;
    JointSpring spring;
    public string inputName = "Flipper";

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        SetSpring(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            SetSpring(-30);
        }
        if (Input.GetKeyUp(KeyCode.Z)) {
            SetSpring(10);
        }
    }

    void SetSpring(float target) {
        spring = hinge.spring;
        spring.spring = 100000;
        spring.damper = 1000;
        spring.targetPosition = target;
        hinge.spring = spring;
    }
}
