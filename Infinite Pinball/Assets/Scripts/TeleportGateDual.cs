using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGateDual : MonoBehaviour
{
    TeleportController controller;

    void Awake() {
        controller = transform.parent.GetComponent<TeleportController>();
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        if (controller.isTeleportFrame) {
            controller.isTeleportFrame = false;
            return;
        }

        controller.teleport(this, collider.gameObject);
    }
}
