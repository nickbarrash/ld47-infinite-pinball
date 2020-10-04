using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] clips;
    public Dictionary<string, Sound> soundMap = new Dictionary<string, Sound>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in clips) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            soundMap[s.name] = s;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(string name) {
        soundMap[name].source.Play();
    }
}
