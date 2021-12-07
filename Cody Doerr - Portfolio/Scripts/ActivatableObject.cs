using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableObject : MonoBehaviour
{
    public enum ActivatableType { Door, Wall, Watcher, Light, Plate };
    public ActivatableType type;
    private bool doorActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        if(type==ActivatableType.Plate)
        {
            GetComponent<PlateController>().Pressed();
        }
        if (type == ActivatableType.Door && !doorActivated)
        {
            doorActivated = true;
            GetComponent<DoorController>().OpenDoor();
        }
        else if (type == ActivatableType.Door && doorActivated)
        {
            doorActivated = false;
            GetComponent<DoorController>().CloseDoor();
        }

    }
}
