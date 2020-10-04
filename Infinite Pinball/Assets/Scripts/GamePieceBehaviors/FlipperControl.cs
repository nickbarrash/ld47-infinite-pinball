using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    HingeJoint hinge;
    JointSpring spring;

    public float power = 100000;
    public float damper = 1000;
    public float contractAngle = -25;
    public float relaxAngle = 10;

    public KeyCode activationKey;

    AudioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        manager = FindObjectOfType<AudioManager>();

        relax();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey)) {
            contract();
        }
        if (Input.GetKeyUp(activationKey)) {
            relax();
        }
    }

    void contract() {
        setSpring(contractAngle);
    }

    void relax() {
        setSpring(relaxAngle);
    }

    void setSpring(float target) {
        spring = hinge.spring;
        spring.spring = power;
        spring.damper = damper;
        spring.targetPosition = target;
        hinge.spring = spring;
    }
}
