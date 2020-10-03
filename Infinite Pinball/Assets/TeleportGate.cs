using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGate : MonoBehaviour
{
    GameObject gateTo;

    void Awake() {
        gateTo = gateTo = transform.parent.Find("GateTo").gameObject;
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        collider.gameObject.transform.position = collider.gameObject.transform.position + (gateTo.transform.position - transform.position);
    }
}
