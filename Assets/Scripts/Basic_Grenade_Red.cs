using System.Collections;
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
    [SerializeField]
    private float _speed = 20.0f;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private string _ownertag;
    [SerializeField]
    Player _player1;
    Player _player2;
    Player _player3;
    Player _player4;
    // Start is called before the first frame update

    private void Start()
    {
        _player1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        _player2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
        _player3 = GameObject.FindWithTag("Player3").GetComponent<Player>();
        _player4 = GameObject.FindWithTag("Player4").GetComponent<Player>();

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

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        GetComponent<Rigidbody>().velocity = direction * _speed * Time.deltaTime;
        Destroy(this.gameObject, 1);

    }

    public void SetOwnerTag(string owner)
    {
        _ownertag = owner;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        {
            collision.collider.GetComponent<Player>().damage();
        }
    }
}