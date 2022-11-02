/**
 * Author: Aidan Pohl
 * Created: Nov 2, 2022
 * 
 *Modified By: N/A
 *Modified: N/A
 *Description: Controls weather effects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Weather_System : MonoBehaviour
{
    public GameObject rainGO;
    ParticleSystem rainPS;
    public AudioMixerSnapshot rainSnapshot;
    public AudioMixerSnapshot sunSnapshot;
    public float rainTime = 10f;

    float timerTime;
    bool startTimer = false;

    AudioSource rainAudio;
    bool isRaining;

    public Volume rainProcess;
    float lerpValue;
    float lerpDuration = 10;
    float transitionTime;

    public bool IsRaining { get { return isRaining; } }
    // Start is called before the first frame update
    void Start()
    {
        rainPS = rainGO.GetComponent<ParticleSystem>();
        rainAudio = rainGO.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        { if (timerTime > 0)
            {
                timerTime -= Time.deltaTime;
                TintSky();
            }
            else
            {
                EndRain();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Rain");
        if(other.tag == "Player")
        {
            if (!startTimer) {
                Debug.Log("Beginning Rainfall");
                timerTime = rainTime;
                startTimer = true;
                isRaining = true;
                rainPS.Play();
                rainAudio.Play();
                rainSnapshot.TransitionTo(2.0f);
            }
        }
    }

    void EndRain()
    {
        Debug.Log("Ending Rainfall");
        startTimer = false;
        isRaining = false;
        rainPS.Stop();
        rainAudio.Stop();
        sunSnapshot.TransitionTo(2.0f);
    }

    void TintSky()
    {
        if( transitionTime < lerpDuration)
        {
            lerpValue = Mathf.Lerp(0, 1, transitionTime / lerpDuration);
            transitionTime += Time.deltaTime;
            rainProcess.weight = lerpValue;
        }
    }
}
