using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundToggle : MonoBehaviour
{
    Material toggleMaterial;

    bool isOn = false;

    void Start() {
        toggleMaterial = GetComponent<Renderer>().material;
        UpdateColor();
    }

    private void OnTriggerEnter(Collider collider) {
        Debug.Log("here");

        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        Debug.Log("here2");

        isOn = !isOn;

        UpdateColor();
    }

    void UpdateColor() {
        if (isOn) {
            toggleMaterial.SetColor("_Color", new Color(1, 1, 0, 1));
        } else {
            toggleMaterial.SetColor("_Color", new Color(0.3f, 0.3f, 0, 1));
        }
    }
}
