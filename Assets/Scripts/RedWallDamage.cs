using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWallDamage : MonoBehaviour
{

    [SerializeField]
    private int walldamage = 25;
    Player _player1;
    Player _player2;
    Player _player3;
    Player _player4;

    private void Start()
    {
        _player1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        _player2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            player.damage(walldamage);
        }
    }
}
