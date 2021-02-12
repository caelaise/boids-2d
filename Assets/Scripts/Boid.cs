using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boid : MonoBehaviour
{

    [HideInInspector] public static List<Boid> boids = new List<Boid>();
    private List<BoidBehavior> behaviors;
    [HideInInspector] public Rigidbody2D rb;
    public float accelerationCapacity;
    public float maxAcceleration;
    public float maxVelocity;
    public float interactionRadius;
    public float minVelocity;
    public float accelerationScale;
    [Range(0f, 1f)]
    [SerializeField] private float separationStrength;
    [Range(0f, 1f)]
    [SerializeField] private float alignnmentStrength;
    [Range(0f, 1f)]
    [SerializeField] private float coherenceStrength;
    [SerializeField] private float separationRadius;
    
    public void Initialize(Vector2 initialVelocity)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;
        behaviors = new List<BoidBehavior> { new SeparationBehavior(separationStrength, separationRadius), new AlignmentBehavior(alignnmentStrength) };
    }



    void Start()
    {
        boids.Add(this);
    }

    void Update()
    {
        Vector2 forceAccum = Vector2.zero;
        float magnitudeAccum = 0;
        foreach (BoidBehavior behavior in behaviors)
        {
            Vector2 force = behavior.strength * behavior.GetForce(this, boids);
            if (magnitudeAccum + force.magnitude > accelerationCapacity)
            {
                forceAccum += (accelerationCapacity - forceAccum.magnitude) * forceAccum;
                break;
            }
            forceAccum += force;
            magnitudeAccum += force.magnitude;
        }

        forceAccum *= accelerationScale;
        
        if (forceAccum.magnitude > maxAcceleration)
        {
            forceAccum = maxAcceleration * forceAccum.normalized;
        }
        rb.AddForce(forceAccum);
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = maxVelocity * rb.velocity.normalized;
        }
        if (rb.velocity.magnitude < minVelocity)
        {
            rb.velocity = minVelocity * rb.velocity.normalized;
        }

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}