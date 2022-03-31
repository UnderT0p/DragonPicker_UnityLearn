using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DragonEgg : MonoBehaviour,IDropItem
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
        if (transform.position.y<bottomY)
        {
            ReturnToPlatform();
            VisibilityOn();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            ChangePlayerHealth();
            VisibilityOff();
            PlayAnimation();
            PlaySound(dropEgg);
        }
        else if(other.tag == "Basket")
        {
            ChangePlayerScore();
            PlaySound(catchEgg);
            VisibilityOff();
            ReturnToPlatform();
            VisibilityOn();
        }
        
    }
    //private void OnCollisionEnter(Collision coll)
    //{
    //    GameObject Collided = coll.gameObject;
    //    if (Collided.tag == "Basket")
    //    {
            
    //        //audioSource = GetComponent<AudioSource>();
    //        //audioSource.Play();
    //    }

    //}


    public void VisibilityOn()
    {
        GetComponent<Renderer>().enabled = true;
    }

    public void VisibilityOff()
    {
        GetComponent<Renderer>().enabled = false;
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

    public void ChangePlayerHealth()
    {
        ScharedData.DecreaseHelth();
        EventManager.eventOnHealthUpdate();
    }

    public void ChangePlayerScore()
    {
        ScharedData.IncreaseScore();
        EventManager.eventOnScoreUpdate();
    }

    public void ReturnToPlatform()
    {
        transform.rotation = platformrotation;
        transform.position = platformposition;
        var em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;
    }
    
}
