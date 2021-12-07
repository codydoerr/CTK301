using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private AudioClip doorOpenClip;
    [SerializeField] private AudioClip doorCloseClip;
    [SerializeField] private AudioSource doorAudioSource;
    [SerializeField] private GameObject audioController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        doorAudioSource.clip = doorOpenClip;
        doorAudioSource.Play();
        audioController.transform.SetParent(null);
        gameObject.SetActive(false);
    }
    public void CloseDoor()
    {
        gameObject.SetActive(true);
        audioController.transform.SetParent(gameObject.transform);
        doorAudioSource.clip = doorCloseClip;
        doorAudioSource.Play();


    }
}
