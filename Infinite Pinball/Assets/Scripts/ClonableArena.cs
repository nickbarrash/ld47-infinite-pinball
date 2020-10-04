using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonableArena : MonoBehaviour
{
    public static bool instantiated = false;

    public float offset = 150f;

    // Start is called before the first frame update
    void Start()
    {
        if (!instantiated) {
            instantiated = true;
            Instantiate(gameObject, transform.position + new Vector3(0, offset, 0), Quaternion.identity);
            Instantiate(gameObject, transform.position - new Vector3(0, offset, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
