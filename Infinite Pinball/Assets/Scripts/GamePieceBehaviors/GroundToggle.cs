using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundToggle : MonoBehaviour
{
    Material toggleMaterial;

    public Color onColor = new Color(1, 1, 0, 1);
    public Color offColor = new Color(0.3f, 0.3f, 0, 1);
    public bool isOn = false;

    public string onSound = "basic-toggle-on";
    public string offSound = "basic-toggle-off";

    AudioManager manager;
    void Awake() {
        manager = FindObjectOfType<AudioManager>();
    }

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
            manager.play(onSound);
            toggleMaterial.SetColor("_Color", onColor);
        } else {
            manager.play(offSound);
            toggleMaterial.SetColor("_Color", offColor);
        }
    }
}
