using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField]
    float speed;

    Rigidbody Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(transform.right * speed);
        }
	}
}
