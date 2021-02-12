using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBound : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.position.x > 0)
        {
            other.attachedRigidbody.position = new Vector2(-16, other.attachedRigidbody.position.y);
        }
        else
        {
            other.attachedRigidbody.position = new Vector2(16, other.attachedRigidbody.position.y);
        }

    }
}
