using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    [SerializeField]
    private Wall wall;
    [SerializeField]
    private float _mSpeed = 5.0f;
    [SerializeField]
    private float _fireRate = 0.2f;
    [SerializeField]
    private float _cantFire = -1.0f;
    [SerializeField]
    private int _lives = 5;
    [SerializeField]
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _basicBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(7.0f, 13.0f), 0.75f, Random.Range(0.0f, -8.0f));
        wall = GameObject.Find("Wall").GetComponent<Wall>();
        if (wall == null)
        {
            Debug.LogError(" Wall is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
