using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBound : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.position.y > 0)
        {
            other.attachedRigidbody.position = new Vector2(other.attachedRigidbody.position.x, -9);
        }
        else
        {
            other.attachedRigidbody.position = new Vector2(other.attachedRigidbody.position.x, 9);
        }

    }
}
