using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Bullet_Blue : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20.0f;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private string _ownertag;
    [SerializeField]
    private int bulletdamage = 1;
    [SerializeField]
    Player _player1;
    Player _player2;
    Player _player3;
    Player _player4;
    
    private void Start()
    {
       // _player = GameObject.Find("Player").GetComponent<Player>();
        _player1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        _player2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
        _player3 = GameObject.FindWithTag("Player3").GetComponent<Player>();
        _player4 = GameObject.FindWithTag("Player4").GetComponent<Player>();

        //_player1._team = "Blue";
        //_player2._team = "Blue";
        //_player3._team = "Red";
        //_player4._team = "Red";

    }
    // Update is called once per frame
    void Update()
    {
    
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("hit trigger");
    //    if (other.tag == "Player1")
    //    {
    //        _player1.damage();
    //        Destroy(_player3.gameObject);
    //    }
    //    else if (other.tag == "Player2")
    //    {
    //        _player2.damage();
    //        Destroy(_player3.gameObject);
    //    }

    //    // other.GetComponent<Player>();
    //    else if (other.tag == "Player3")
    //    {
    //        _player3.damage();
    //        Destroy(_player3.gameObject);
    //    }
    //   else if (other.tag == "Player4")
    //    {
    //        _player4.damage();
    //        Destroy(_player3.gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player3" || collision.collider.tag == "Player4")
        {
            collision.collider.GetComponent<Player>().damage(bulletdamage);
        }
    }
}
