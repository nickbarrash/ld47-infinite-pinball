using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundToggle : ScoreableComponent
{
    Material toggleMaterial;

    public Color onColor = new Color(1, 1, 0, 1);
    public Color offColor = new Color(0.3f, 0.2f, 0, 1);
    public bool isOn = false;

    public string onSound = "basic-toggle-on";
    public string offSound = "basic-toggle-off";

    AudioManager manager;

    public bool isLatch = false;
    public float offDelay = -1f;
    float offTimer = 0;

    private string copyPath = "";
    GroundToggle twinTop;
    GroundToggle twinBottom;

    void Start() {
        manager = FindObjectOfType<AudioManager>();
        toggleMaterial = GetComponent<Renderer>().material;
        UpdateColor();

        List<string> names = new List<string>();
        Transform curr = transform;
        while (curr.parent != null) {
            names.Add(curr.name);
            curr = curr.parent;
        }

        names.Reverse();
        copyPath = string.Join("/", names.ToArray());

        twinTop = GameObject.Find("/ArenaTop/" + copyPath).GetComponent<GroundToggle>();
        twinBottom = GameObject.Find("/ArenaBottom/" + copyPath).GetComponent<GroundToggle>();

    }

    private void Update() {
        if (offTimer > 0) {
            offTimer -= Time.deltaTime;
            if (offTimer <= 0) {
                resetState();
            }
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Ball")) {
            return;
        }

        if (isLatch) {
            if (!isOn) {
                turnOn();
            }
        } else {
            // toggle
            if (isOn) {
                turnOff();
            } else {
                turnOn();
            }
        }

        UpdateColor();
    }

    public void setOnLite(bool newIsOn) {
        isOn = newIsOn;
        UpdateColor();
    }

    public void setTwins(bool newIsOn) {
        twinTop.setOnLite(newIsOn);
        twinBottom.setOnLite(newIsOn);
    }

    void turnOn() {
        setOnLite(true);
        setTwins(true);

        score();
        manager.play(onSound);

        if (offDelay > 0) {
            offTimer = offDelay;
        }
        activate();
    }

    void turnOff(bool playSound = true) {
        setOnLite(false);
        setTwins(false);
        if (playSound) {
            manager.play(offSound);
        }
        deactivate();
    }

    void UpdateColor() {
        if (isOn) {
            toggleMaterial.SetColor("_Color", onColor);
        } else {

            toggleMaterial.SetColor("_Color", offColor);
        }
    }

    public override void resetState() {
        base.resetState();
        turnOff(false);
    }
}
