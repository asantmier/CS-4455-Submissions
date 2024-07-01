using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorBehavior : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Door is missing animator component.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            anim.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            anim.SetBool("IsOpen", false);
        }
    }
}
