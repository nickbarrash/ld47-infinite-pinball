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
            GameObject upperArena = Instantiate(gameObject);
            GameObject lowerArena = Instantiate(gameObject);
            upperArena.transform.position += new Vector3(0, offset, 0);
            lowerArena.transform.position -= new Vector3(0, offset, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
