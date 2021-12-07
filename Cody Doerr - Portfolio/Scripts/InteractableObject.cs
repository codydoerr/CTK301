using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractableType { Box,Switch,Lever };
    public InteractableType type;
    private PlayerController pc;
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void LateUpdate()
    {
        if (transform.parent != null)
        {
            if (transform.parent.tag == "Player")
            {
                grabbed = true;
                gameObject.layer = 0;
            }
        }
        else
        {
            grabbed = false;
            gameObject.layer = 10;
        }
    }
    public void Interact(GameObject curGo)
    {
            switch (type)
            {
                case InteractableObject.InteractableType.Box:
                    {
                        transform.SetParent(pc.transform);
                        pc.heldObject = curGo;
                        return;
                    }
                case InteractableObject.InteractableType.Switch:
                    {
                        return;
                    }
                case InteractableObject.InteractableType.Lever:
                    {
                        curGo.GetComponent<LeverController>().Flipped();
                        
                        return;
                    }
            }

        }
    public void CheckCollide(Vector2 direction)
    {
        int layerMask = (LayerMask.GetMask("StopsMovement"));
        RaycastHit2D rc = Physics2D.Raycast(transform.position - new Vector3(0, 0.5f, 0), direction, .6f, layerMask);
        Debug.DrawRay(transform.position - new Vector3(0, 0.5f, 0), direction, Color.blue, 1);
        if (rc.collider != null)
        {
            DropObject();
        }
    }
    public void DropObject()
    {
        grabbed = false;
        gameObject.layer = 10;
        transform.SetParent(null);
        FindObjectOfType<PlayerController>().heldObject = null;
    }
}
