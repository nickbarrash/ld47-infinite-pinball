using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    TeleportGateDual gate1;
    TeleportGateDual gate2;

    public float bufferMagnitude = 0.97f;

    [HideInInspector]
    public bool isTeleportFrame = false;

    void Awake() {
        gate1 = transform.Find("Gate1").gameObject.GetComponent<TeleportGateDual>();
        gate2 = transform.Find("Gate2").gameObject.GetComponent<TeleportGateDual>();
    }

    public void teleport(TeleportGateDual gate, GameObject pinball) {
        pinball.transform.position = (
                pinball.transform.position +
                (
                    (
                        getOtherGate(gate).transform.position
                    //- new Vector3(0, getOtherGate(gate).transform.localScale.y / 2, 0)
                    ) -
                    (
                        gate.transform.position
                    //+ new Vector3(0, gate.transform.localScale.y / 2, 0)
                    )
                )
            ); // * bufferMagnitude;
        isTeleportFrame = true;
    }

    private TeleportGateDual getOtherGate(TeleportGateDual gate) {
        return gate1 == gate ? gate2 : gate1;
    }
}
