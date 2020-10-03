using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundToggle : MonoBehaviour
{
    Material toggleMaterial;

    public Color onColor = new Color(1, 1, 0, 1);
    public Color offColor = new Color(0.3f, 0.3f, 0, 1);
    public bool isOn = false;

    void Start() {
        toggleMaterial = GetComponent<Renderer>().material;
        UpdateColor();
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        isOn = !isOn;

        UpdateColor();
    }

    void UpdateColor() {
        if (isOn) {
            toggleMaterial.SetColor("_Color", onColor);
        } else {
            toggleMaterial.SetColor("_Color", offColor);
        }
    }
}
