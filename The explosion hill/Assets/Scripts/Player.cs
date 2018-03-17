using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {


    [SerializeField]
    AudioSource Gaz;

    [SerializeField]
    AudioSource Audio;
    [SerializeField]
    ParticleSystem[] Explosion;
    [SerializeField]
    float speed = 30;

    Canvas Canvas;
    Rigidbody Rigidbody;
    Camera Camera;
    Collider Collider;

    AudioSource gaz;

    Text Long;
    Text Height;
    Text Points;
    public bool isDestroy = false;

    int bestLong = 0 ;
    int bestHeight = 0;
    bool gazBool = true;
    bool onHill = true;

    private void Awake()
    {
        gaz = Instantiate(Gaz);
        gaz.Stop();
        Camera = FindObjectOfType<Camera>();
        Rigidbody = GetComponent<Rigidbody>();
        Canvas = FindObjectOfType<Canvas>();
        Long = GameObject.FindGameObjectWithTag("Long").GetComponent<Text>();
        Height = GameObject.FindGameObjectWithTag("Height").GetComponent<Text>();
        Points = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        Collider = GetComponent<BoxCollider>();
    }

    void Update () {

        float vertical = Input.GetAxis("Vertical");

        if(vertical != 0)
        {
            transform.position.Set(
                transform.position.x,
                transform.position.y,
                (int)vertical * 50f);
        }

        if ((Input.GetKeyDown(KeyCode.Space) && onHill) || (Input.touchCount > 0 && onHill))
        { 
            if (gazBool)
            {
                gaz.Play();
                gazBool = false;
            }
            
            Rigidbody.AddForce(transform.forward * speed);
            speed += 50;
        }
        if (transform.position.y > bestHeight)
        {
            bestHeight = (int) transform.position.y;
        }
        if (transform.position.x > bestLong)
        {
            bestLong = (int)transform.position.x;
        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            gaz.Stop();
            //StartCoroutine(Camera.Shake(.15f, .4f));
            var audio = Instantiate(Audio);
            audio.Play();
            isDestroy = true;
            var explosion = Instantiate(Explosion[Random.Range(0,Explosion.Length)]);
            explosion.transform.position = transform.position;
            explosion.transform.localScale *= 5f;
            explosion.Play();
            Long.text = "Distance: " + bestLong + " m";
            Height.text = "Height: " + (int) (transform.position.y + 45)  + " m";
            Points.text = "Points of Explosion: " + (bestLong * (int)(transform.position.y + 45) +1);
            Canvas.enabled = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onHill = false;
        Debug.Log("eloelo");
    }
}
