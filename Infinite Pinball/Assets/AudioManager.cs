using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool sound = true;

    public Sound[] clips;
    public Dictionary<string, Sound> soundMap = new Dictionary<string, Sound>();

    GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        foreach (Sound s in clips) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * 0.1f;
            s.source.pitch = s.pitch;

            soundMap[s.name] = s;
        }
    }

    private void Start() {
        gameManager.setSound(sound);
        play("theme", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.M)) {
            play("click-1");
        }
    }

    public void toggleSound() {
        sound = !sound;
        gameManager.setSound(sound);
    }

    public void play(string name, bool loop = false) {
        if (sound) {
            if (loop) {
                soundMap[name].source.loop = true;
            }
            soundMap[name].source.Play();
        }
    }
}
