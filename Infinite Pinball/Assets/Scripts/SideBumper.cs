using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBumper : MonoBehaviour
{
    public float power = 200f;
    public float speedCap = 10f;

    ScorePoints points;
    void Awake() {
        points = GetComponent<ScorePoints>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * power, ForceMode.Impulse);

        if (points != null) {
            points.score();
        }
    }
}
