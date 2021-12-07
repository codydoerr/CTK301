using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ExitDoorController : MonoBehaviour
{
    [SerializeField] private Vector3 exitLocation;
    [SerializeField] private enum Direction { Up,Down,Left,Right};
    [SerializeField] private Direction whereExit;

    Animator animator;

    GameObject gC;
    private void Start()
    {
        animator = GameObject.Find("SceneTransition").GetComponent<Animator>();
        switch (whereExit)
        {
            case Direction.Up:
                exitLocation = transform.parent.position + new Vector3(0, 1);
                break;
            case Direction.Down:
                exitLocation = transform.parent.position + new Vector3(0, -1);
                break;
            case Direction.Left:
                exitLocation = transform.parent.position + new Vector3(-1, 0);
                break;
            case Direction.Right:
                exitLocation = transform.parent.position + new Vector3(1, 0);
                break;
        }
        transform.position = exitLocation;
        transform.SetParent(null);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetTrigger("FadeOutTrigger");
        }
    }
}
