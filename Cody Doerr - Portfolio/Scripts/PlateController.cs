using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    [SerializeField] private AudioClip plateDownClip;
    [SerializeField] private AudioClip plateUpClip;
    [SerializeField] private AudioSource plateAudioSource;

    private bool platePressed = false;

    [Tooltip("Place an Activatable GameObject here!")]
    public ActivatableObject activateFromPlate;
    [Tooltip("Start with the item in the opposite state")]
    public bool startActivated = false;


    // Start is called before the first frame update
    void Start()
    {
        if (startActivated)
        {
            activateFromPlate.Activate();
        }
    }

    void Update()
    {
        
    }
    public void Pressed()
    {
        if (platePressed == false)
        {
            plateAudioSource.clip = plateDownClip;
            plateAudioSource.Play();
            platePressed = true;
            activateFromPlate.Activate();
        }
        else if(platePressed ==true)
        {
            plateAudioSource.clip = plateUpClip;
            plateAudioSource.Play();
            platePressed = false;
            activateFromPlate.Activate();
        }
    }
}
