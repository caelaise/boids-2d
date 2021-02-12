using System.Collections.Generic;
using UnityEngine;

class AlignmentBehavior : BoidBehavior
{

    public AlignmentBehavior(float alignmentStrength) : base(alignmentStrength) { }
    public override Vector2 GetForce2(Boid thisBoid, List<Boid> localBoids)
    {
        if (localBoids.Count == 0)
        {
            return Vector2.zero;
        }
        Vector2 averageDir = Vector2.zero;
        foreach (Boid b in localBoids)
        {
            averageDir += b.rb.velocity.normalized;
        }
        averageDir = averageDir / localBoids.Count;
        float angle = Vector2.Angle(averageDir, thisBoid.rb.velocity);
        float forceMagnitude = angle / 180;
        Vector2 force = strength * forceMagnitude * averageDir.normalized;
        return force;
    }
}
