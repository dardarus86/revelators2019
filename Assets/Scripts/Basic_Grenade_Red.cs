﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Grenade_Red : MonoBehaviour
{
    public float delay = 4f;
    public float radius = 5f;
    public float force = 700f;
    // protected float animation;

    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;

    }

    // Update is called once per frame
    void Update()
    {
        //animation += Time.deltaTime;
        //animation = animation % 5;
        //transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 10f, 5f, animation / 5f);
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
    void Explode()
    {

        Instantiate(explosionEffect, transform.position, transform.rotation);


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
