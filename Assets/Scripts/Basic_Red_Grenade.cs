using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Red_Grenade : MonoBehaviour
{
    public float delay = 4f;
    public float radius = 5f;
    public float force = 700f;
    // protected float animation;
    [SerializeField]
    private int grenadedamage = 25;
    float countdown;
    bool hasExploded = false;

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

        countdown = delay;

    }

    // Update is called once per frame
    void Update()
    {
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
        Destroy(this.gameObject, 4.1f);

    }

    public void SetOwnerTag(string owner)
    {
        _ownertag = owner;
    }

    void Explode()
    {

        // Instantiate(explosionEffect, transform.position, transform.rotation);


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Player player = nearbyObject.GetComponent<Player>();
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);

                if (player.tag == "Player1" || player.tag == "Player2")
                {
                    player.damage(grenadedamage);
                }

            }
        }
        Destroy(gameObject);
    }


}
