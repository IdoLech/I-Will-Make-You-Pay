﻿using UnityEngine;
using System.Collections;

public class player1 : MonoBehaviour {
    Transform myTransform;
    public float moveSpeed;
    public float maxHealth;
    public float currentHealth;
    public float funds;
    public static player1 main;
    public bullet bullet;
    // Use this for initialization
    void Start () {
        myTransform = GetComponent<Transform>();
        currentHealth = maxHealth;
        main = this;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {           
            myTransform.position += myTransform.forward * Time.deltaTime * moveSpeed;
            Vector3 lookPoint = new Vector3(0, 0, 90);
            transform.rotation = Quaternion.LookRotation(lookPoint);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 lookPoint = new Vector3(0, 0, -90);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 lookPoint = new Vector3(-90, 0, 0);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward * Time.deltaTime * moveSpeed;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 lookPoint = new Vector3(90, 0, 0);
            transform.rotation = Quaternion.LookRotation(lookPoint);
            myTransform.position += myTransform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet.direction = transform.forward;
            Instantiate(bullet, transform.position + transform.forward, transform.rotation);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "p2")
        {
            currentHealth -= col.gameObject.GetComponent<bullet>().damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
