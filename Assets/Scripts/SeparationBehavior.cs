using System.Collections.Generic;
using UnityEngine;

class SeparationBehavior : BoidBehavior
{

    readonly float separationRadius;

    public SeparationBehavior(float separationStrength, float separationRadius) : base(separationStrength) => this.separationRadius = separationRadius;
    public override Vector2 GetForce2(Boid thisBoid, List<Boid> localBoids)
    {
        if (localBoids.Count == 0)
        {
            return Vector2.zero;
        }
        Vector2 force = Vector2.zero;
        foreach (Boid b in localBoids)
        {
            
            Vector2 displacement = b.rb.position - thisBoid.rb.position;
            if (displacement.magnitude < separationRadius)
            {
                float forceMagnitude = 1 - displacement.magnitude / separationRadius;
                force += strength * forceMagnitude * -displacement.normalized;
            }
        }
        return force;
    }
}