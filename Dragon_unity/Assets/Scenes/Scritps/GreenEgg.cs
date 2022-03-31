using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEgg : MonoBehaviour, IDropItem
{
    [SerializeField] private float bottomY = -10;
    [SerializeField] private AudioClip catchEgg;
    [SerializeField] private AudioClip dropEgg;

    private Vector3 platformposition;
    private AudioSource audioSource;
    private Quaternion platformrotation;


    private void Awake()
    {
        platformposition = transform.position;
        platformrotation = transform.rotation;
    }
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            ReturnToPlatform();
            VisibilityOn();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            VisibilityOff();
            PlayAnimation();
            PlaySound(dropEgg);
        }
        else if (other.tag == "Basket")
        {
            ChangePlayerScore();
            PlaySound(catchEgg);
            VisibilityOff();
            ReturnToPlatform();
            VisibilityOn();
        }

    }
    public void ChangePlayerScore()
    {
        ScharedData.Score-=5;
        EventManager.eventOnScoreUpdate();
    }

    public void ChangePlayerHealth()
    {
        
    }

    public void PlayAnimation()
    {
        var em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = ScharedData.Volume;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void ReturnToPlatform()
    {
        transform.rotation = platformrotation;
        transform.position = platformposition;
        var em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;
    }

    public void VisibilityOff()
    {
        GetComponent<Renderer>().enabled = false;
    }

    public void VisibilityOn()
    {
        GetComponent<Renderer>().enabled = true;
    }
}
