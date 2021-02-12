using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BoidBehavior
{
    public abstract Vector2 GetForce(Boid thisBoid, List<Boid> allBoids);
}
