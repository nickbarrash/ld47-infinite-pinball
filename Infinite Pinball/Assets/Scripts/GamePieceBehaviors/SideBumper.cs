using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBumper : ScoreableComponent {
    public float power = 200f;

    AudioManager manager;


    void Start() {
        manager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        manager.play("side-bumper-1");

        collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * power * -1, ForceMode.Impulse);

        score();
    }
}
