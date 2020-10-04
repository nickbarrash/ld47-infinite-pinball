﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperControl : ScoreableComponent
{
    public float power = 100f;

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        Vector3 direction = new Vector3(
            collider.gameObject.transform.position.x - transform.position.x,
            collider.gameObject.transform.position.y - transform.position.y,
            0
        ).normalized * power;

        collider.gameObject.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);

        score();
    }
}