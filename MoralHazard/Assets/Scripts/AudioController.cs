using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioClip sound30;
    public AudioClip sound50;
    public AudioClip sound80;
    private AudioSource audio_source;
    private int old_stress = 50;

    void Start()
    {
        audio_source = this.GetComponent<AudioSource>();

    }

    void Update()
    {
        int new_stress = StoryController.getStress();

        if (old_stress != new_stress)
        {
            ChengeMusic(new_stress);
        }

        old_stress = new_stress;
    }

    private void ChengeMusic(int score)
    {

        if (score <= 30)
        {
            audio_source.clip = sound30;
            audio_source.Play();
        }
        else if (score >= 80)
        {
            audio_source.clip = sound80;
            audio_source.Play();
        }
        else
        {
            audio_source.clip = sound50;
            audio_source.Play();
        }
    }
}
