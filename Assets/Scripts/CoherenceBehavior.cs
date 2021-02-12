using System.Collections.Generic;
using UnityEngine;

class CoherenceBehavior : BoidBehavior
{

    public CoherenceBehavior(float coherenceStrength) : base(coherenceStrength) { }
    public override Vector2 GetForce2(Boid thisBoid, List<Boid> localBoids)
    {
        if (localBoids.Count == 0)
        {
            return Vector2.zero;
        }
        Vector2 avgPos = Vector2.zero;
        foreach (Boid b in localBoids)
        {
            avgPos += b.rb.position;
        }
        avgPos = avgPos / localBoids.Count;
        Vector2 displacement = avgPos - thisBoid.rb.position;
        float forceMagnitude = displacement.magnitude / thisBoid.interactionRadius;
        Vector2 force = forceMagnitude * strength * displacement.normalized;
        return force;
    }
}