using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBumper : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * 200f, ForceMode.Impulse);
    }
}
