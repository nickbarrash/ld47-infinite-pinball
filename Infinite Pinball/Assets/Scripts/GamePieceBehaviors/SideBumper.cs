using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBumper : MonoBehaviour
{
    public float power = 200f;

    ScorePoints points;
    void Awake() {
        points = GetComponent<ScorePoints>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        Debug.Log(collision.contacts[0].normal * power);

        collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * power * -1, ForceMode.Impulse);

        if (points != null) {
            points.score();
        }
    }
}
