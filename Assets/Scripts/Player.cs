using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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
        transform.position = new Vector3(Random.Range(-2.1f, 4.0f), 0.75f, Random.Range(-0.2f, -7.0f));
        wall = GameObject.Find("Wall").GetComponent<Wall>();
        if(wall == null)
        {
            Debug.LogError(" Wall is NULL");
        }

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.JoystickButton7) && Time.time > _cantFire)
        {
            FireBasicBullet();
        }
        calculateRotation();
    }

    void CalculateMovement()
    {
        float LhorizonalInput = Input.GetAxis("LHorizontal");
        float LverticalInput =  Input.GetAxis("LVertical");

        Vector3 direction = new Vector3(LhorizonalInput, 0, LverticalInput);

        transform.Translate(direction * _mSpeed * Time.deltaTime, Space.World);
    }

    void calculateRotation()
    {
        float RhorizontalInput = Input.GetAxis("RHorizontal");
        float RverticalInput = Input.GetAxis("RVertical");
        print(RhorizontalInput + ", " + RverticalInput);
        transform.LookAt(transform.position + new Vector3(RhorizontalInput, 0, RverticalInput), Vector3.up);
   
    }

    void FireBasicBullet()
    {
        _cantFire = Time.time + _fireRate;

        GameObject newBullet = Instantiate(_basicBulletPrefab, transform.position + transform.forward, Quaternion.identity);
        newBullet.GetComponent<Basic_Bullet>().SetDirection(transform.forward);
        newBullet.GetComponent<Basic_Bullet>().SetOwnerTag(gameObject.tag);
    }
}
