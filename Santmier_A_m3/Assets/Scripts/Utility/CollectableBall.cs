using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            BallCollector bc = other.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if (bc != null)
            {
                bc.RecieveBall();
                EventManager.TriggerEvent<BombBounceEvent, Vector3>(other.transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}
