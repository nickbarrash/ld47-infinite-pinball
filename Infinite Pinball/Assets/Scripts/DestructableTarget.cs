using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableTarget : ScoreableComponent {
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        gameObject.SetActive(false);

        score();
        activate();
    }

    public override void resetState() {
        gameObject.SetActive(true);
        deactivate();
    }
}
