using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSorseMainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        EventManager.eventOnSoundChange += ChangeVolumeMainCameraAudioSorse;
    }
    void OnDisable()
    {
        EventManager.eventOnSoundChange -= ChangeVolumeMainCameraAudioSorse;
    }
    private void ChangeVolumeMainCameraAudioSorse()
    {
        gameObject.GetComponent<AudioSource>().volume = ScharedData.VolumeMusic;
    }
    void Update()
    {
        
    }
}
