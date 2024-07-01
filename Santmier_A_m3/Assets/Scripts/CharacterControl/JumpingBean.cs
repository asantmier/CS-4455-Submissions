using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBean : MonoBehaviour
{
    private int groundContactCount = 0;
    private float timeSinceLastJump = 0;
    private float nextJump = 0;
    private Rigidbody body;

    public float minForce = 1000f;
    public float maxForce = 5000f;
    public float minTime = 1f;
    public float maxTime = 3f;

    public bool IsGrounded
    {
        get
        {
            return groundContactCount > 0;
        }
    }

    void Start()
    {
        body = GetComponent<Rigidbody>();
        nextJump = Random.Range(minTime, maxTime);
    }

    void FixedUpdate()
    {
        if (!IsGrounded) return;
        
        timeSinceLastJump += Time.deltaTime;
        if (timeSinceLastJump >= nextJump)
        {
            Vector3 direction = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)) * Vector3.forward;
            float force = Random.Range(minForce, maxForce);
            body.AddForce(direction * force, ForceMode.Impulse);

            timeSinceLastJump = 0;
            nextJump = Random.Range(minTime, maxTime);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject.tag == "ground")
        {

            ++groundContactCount;

            // Generate an event that might play a sound, generate a particle effect, etc.
            EventManager.TriggerEvent<PlayerLandsEvent, Vector3, float>(collision.contacts[0].point, collision.impulse.magnitude);

        }

    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.transform.gameObject.tag == "ground")
        {
            --groundContactCount;
        }

    }
}
