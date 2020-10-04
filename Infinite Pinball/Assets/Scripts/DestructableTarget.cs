using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableTarget : ScoreableComponent {
    AudioManager manager;

    private void Awake() {
        manager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        manager.play("target-1");

        gameObject.SetActive(false);

        score();
        activate();
    }

    public override void resetState() {
        gameObject.SetActive(true);
        deactivate();
    }
}
