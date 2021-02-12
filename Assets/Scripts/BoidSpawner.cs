using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoidSpawner : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    [SerializeField] int number;
    [SerializeField] float initialMaxSpeed;
    [SerializeField] float initialMinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number + 1; i++)
        {
            GameObject boidObject = Instantiate(prefab, new Vector2(Random.Range(-16, 16), Random.Range(-9, 9)), Quaternion.identity) as GameObject;
            Boid boid = boidObject.GetComponent<Boid>();
            float initialSpeed = Random.Range(initialMinSpeed, initialMaxSpeed);
            float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
            Vector2 initialDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 initialVelocity = initialSpeed * initialDirection;
            boid.Initialize(initialVelocity);
        }
    }

}