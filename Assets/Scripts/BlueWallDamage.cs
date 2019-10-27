using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWallDamage : MonoBehaviour
{
    [SerializeField]
    private int walldamage = 25;
 
    Player _player3;
    Player _player4;

    private void Start()
    {
        _player3 = GameObject.FindWithTag("Player3").GetComponent<Player>();
        _player4 = GameObject.FindWithTag("Player4").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (other.tag == "Player3" || other.tag == "Player4")
        {
            player.damage(walldamage);
        }
    }
}
