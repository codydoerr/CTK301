using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour {
    private bool leverFlipped = false;
    [SerializeField] private bool startActivated = false;
    [SerializeField] private Sprite leverSpriteOn;
    [SerializeField] private Sprite leverSpriteOff;
    [SerializeField] private SpriteRenderer sR;
    [SerializeField] private AudioClip leverAudioOn;
    [SerializeField] private AudioClip leverAudioOff;
    [SerializeField] private AudioSource leverAudioSource;


    [Tooltip("Place an Activatable GameObject here!")]
    public ActivatableObject activateFromLever;
    // Start is called before the first frame update
    void Start()
    {
        if (startActivated)
        {
            activateFromLever.Activate();
        }
    }

    void Update()
    {
        if (leverFlipped)
        {
            sR.sprite = leverSpriteOn;
        }
        else
        {
            sR.sprite = leverSpriteOff;
        }
    }
    public void Flipped()
    {
        if (leverFlipped == false)
        {
            leverFlipped = true;
            leverAudioSource.clip = leverAudioOn;
            leverAudioSource.Play();
            activateFromLever.Activate();
        }
        else if (leverFlipped == true)
        {
            leverFlipped = false;
            leverAudioSource.clip = leverAudioOff;
            leverAudioSource.Play();
            activateFromLever.Activate();
        }
    }
}
