using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BoidBehavior
{
    readonly public float strength;

    protected BoidBehavior(float str) => strength = str;

    public Vector2 GetForce(Boid thisBoid, List<Boid> allBoids)
    {
        List<Boid> localBoids = allBoids.FindAll(b => b != thisBoid & Vector2.Distance(b.transform.position, thisBoid.transform.position) < b.interactionRadius);
        return GetForce2(thisBoid, localBoids);
    }
    public abstract Vector2 GetForce2(Boid thisBoid, List<Boid> localBoids);
}
