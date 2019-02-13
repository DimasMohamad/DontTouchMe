﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public GameObject deathParticles;
    private float maxSpeed = 8f;
    private Vector3 input;
    private Vector3 spawn;

	void Start () {
        spawn = transform.position;
	}
	
	void Update () {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
        if (transform.position.y < -2)
        {
            Die();
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Goal")
        {
            GameManager.CompleteLevel();
        }
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.Euler(270,0,0));
        transform.position = spawn;
    }
}