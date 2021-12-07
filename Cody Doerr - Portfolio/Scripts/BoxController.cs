using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    private Vector2 directionFacing;
    public SpriteRenderer sR;

    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<ActivatableObject>() != null)
        {

            if (collision.gameObject.GetComponent<ActivatableObject>().type == ActivatableObject.ActivatableType.Plate)
            {
                Debug.Log("Sent boi");
                collision.GetComponent<ActivatableObject>().Activate();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ActivatableObject>() != null)
        {

            if (collision.gameObject.GetComponent<ActivatableObject>().type == ActivatableObject.ActivatableType.Plate)
            {
                Debug.Log("Sent boi");
                collision.GetComponent<ActivatableObject>().Activate();
            }
        }
    }
}
