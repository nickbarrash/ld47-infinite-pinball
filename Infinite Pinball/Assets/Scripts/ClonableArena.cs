using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonableArena : MonoBehaviour
{
    public static bool instantiated = false;

    public float offset = 150f;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instantiated) {
            instantiated = true;
            Instantiate(gameObject, transform.position + new Vector3(0, offset, 0), Quaternion.identity).name = "ArenaTop";
            Instantiate(gameObject, transform.position - new Vector3(0, offset, 0), Quaternion.identity).name = "ArenaBottom";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
