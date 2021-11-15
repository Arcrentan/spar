using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDuration : MonoBehaviour
{
    float time;
    float currentTime;

    void Start()
    {
        if (!SoundController.MuteSound)
        {
            this.GetComponent<AudioSource>().Play();
        }
        time = GetComponent<ParticleSystem>().main.duration;
    }

    void Update()
    {
        if (currentTime <= time)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
