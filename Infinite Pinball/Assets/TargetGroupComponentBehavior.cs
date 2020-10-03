using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGroupComponentBehavior : ComponentGroupBehavior {

    public float resetDelay = 0f;
    private float resetTime = 0f;
    private bool resetting = false;

    public void Update() {
        if (resetting) {
            resetTime -= Time.deltaTime;
            if (resetTime <= 0) {
                delayedDeactivate();
            }
        }
    }

    private void delayedDeactivate() {
        deactivateAll();
        resetting = false;
    }

    public override void allActivated() {
        base.allActivated();
        resetting = true;
        resetTime = resetDelay;
    }
}
