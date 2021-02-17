using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioClip whooshSFX;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void playSound()
    {
        if (whooshSFX)
            audio.PlayOneShot(whooshSFX, 0.2f);
    }

    public void changeSound(float newSound)
    {
        audio.volume = newSound;
    }
}
