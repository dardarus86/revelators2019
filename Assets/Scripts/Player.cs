using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField]
    private string LHorizontal = "LHorizontal";
    [SerializeField]
    private string LVertical = "LVertical";
    [SerializeField]
    private string RHorizontal = "RHorizontal";
    [SerializeField]
    private string Rvertical = "RVertical";
    [SerializeField]
    private string Controller = "0";
    //[SerializeField]
    //private string Controller1 = "Controller1";
    //[SerializeField]
    //private string Controller2 = "Controller2";
    //[SerializeField]
    //private string Controller3 = "Controller3";
    [SerializeField]
    private Wall wall;
    [SerializeField]
    private float _mSpeed = 5.0f;
    [SerializeField]
    private float _fireRate = 0.2f;
    [SerializeField]
    private float _cantFire = -1.0f;
    [SerializeField]
    private int _lives = 100;
    [SerializeField]
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _blueBulletPrefab;
    [SerializeField]
    private GameObject _redBulletPrefab;
    [SerializeField]
    private GameObject _blueGrenadePrefab;
    [SerializeField]
    private GameObject _redGrenadePrefab;
    [SerializeField]
    public GameObject spawn;
    [SerializeField]
    public string _team;
    [SerializeField]
    public AudioClip _fireSoundClip;
    [SerializeField]
    public AudioClip _deathSoundClip;
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    public Slider health;

    private bool _isDead = false;

    private Vector3 forwardd;


    Vector3 direction = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {

      if (gameObject.tag == "Player1" || gameObject.tag == "Player2")
        {
           this.transform.position = new Vector3(Random.Range(-8.5f, 2.46f), 0.75f, Random.Range(-3.0f, -13.50f));
        }
        if (gameObject.tag == "Player3" || gameObject.tag == "Player4")
        {
            this.transform.position = new Vector3(Random.Range(6.3f, 18.0f), 3.75f, Random.Range(-2.72f, -11.0f));
        }


        //_shootSource = GetComponent<AudioSource>();
        //if (_shootSource == null)
        //{
        //    Debug.LogError("Audio Source is NULL");
        //}
        //else
        //{
        //    _shootSource.clip = _fireSoundClip;
        //}
        _audio = GetComponent<AudioSource>();

        if (_audio == null)
        {
            Debug.LogError("Audio source on player is NULL");
        }
        else
        {
           _audio.clip = _fireSoundClip;
        }


        wall = GameObject.Find("centerpiece").GetComponent<Wall>();
        if(wall == null)
        {
            Debug.LogError(" Wall is NULL");
        }

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Controller == "1")
        {
            
            if (Input.GetKey(KeyCode.Joystick1Button7) && Time.time > _cantFire)
            {
                print("controller 1 fired" + " " + Input.GetJoystickNames());
                FireBasicBullet();
                _audio.Play();
            }
            if (Input.GetKey(KeyCode.Joystick1Button6) && Time.time > _cantFire)
            {
                print("controller 1 fired" + " " + Input.GetJoystickNames());
                Grenade();
                
            }
        }
        if (Controller == "2")
        {
            if (Input.GetKey(KeyCode.Joystick2Button7) && Time.time > _cantFire)
            {
                print("controller 2 fired" + " " + Input.GetJoystickNames());
                FireBasicBullet();
                _audio.Play();
            }
            if (Input.GetKey(KeyCode.Joystick2Button6) && Time.time > _cantFire)
            {
                print("controller 1 fired" + " " + Input.GetJoystickNames());
                Grenade();

            }
        }
        if (Controller == "3")
        {
            if (Input.GetKey(KeyCode.Joystick3Button7) && Time.time > _cantFire)
            {
                print("controller 3 fired");
                FireBasicBullet();
                _audio.Play();
            }
        }
        if (Controller == "4")
        {
            if (Input.GetKey(KeyCode.Joystick4Button7) && Time.time > _cantFire)
            {
                print("controller 3 fireda");
                FireBasicBullet();
                _audio.Play();
            }
        }
        calculateRotation();
    }

    void CalculateMovement()
    {
        float LhorizonalInput = Input.GetAxis(LHorizontal);
        float LverticalInput =  Input.GetAxis(LVertical);

        Vector3 direction = new Vector3(LhorizonalInput, 0, LverticalInput);

        transform.Translate(direction * _mSpeed * Time.deltaTime, Space.World);
    }

    void calculateRotation()
    {
        float RhorizontalInput = Input.GetAxis(RHorizontal);
        float RverticalInput = Input.GetAxis(Rvertical);
    
        transform.LookAt(transform.position + new Vector3(RhorizontalInput, 0, RverticalInput), Vector3.up);
   
    }

    void FireBasicBullet()
    {
        _cantFire = Time.time + _fireRate;
        if( _team == "Blue")
        {
            GameObject newBullet = Instantiate(_blueBulletPrefab, transform.position + transform.forward, Quaternion.identity);
            newBullet.GetComponent<Basic_Bullet_Blue>().SetDirection(transform.forward);
            newBullet.GetComponent<Basic_Bullet_Blue>().SetOwnerTag(gameObject.tag);
        }

        else if( _team == "Red")
        {
            GameObject newBullet = Instantiate(_redBulletPrefab, transform.position + transform.forward, Quaternion.identity);
            newBullet.GetComponent<Basic_Bullet_Red>().SetDirection(transform.forward);
            newBullet.GetComponent<Basic_Bullet_Red>().SetOwnerTag(gameObject.tag);
        }
    }

    void Grenade()
    {
        
        _cantFire = Time.time + _fireRate;
        if (_team == "Blue")
        {
            direction = transform.forward + (transform.rotation * new Vector3(0, 70, 70));
            print(" Blue team");
            GameObject newGrenade = Instantiate(_blueGrenadePrefab, transform.position + transform.forward, Quaternion.identity);
            print(" instantiated");
            newGrenade.GetComponent<Basic_Blue_Grenade>().SetDirection(direction);
            newGrenade.GetComponent<Basic_Blue_Grenade>().SetOwnerTag(gameObject.tag);
            print(" set direction and set tag");

        }

        else if (_team == "Red")
        {
            GameObject newGrenade = Instantiate(_redGrenadePrefab, transform.position + transform.forward, Quaternion.identity);
            newGrenade.GetComponent<Basic_Red_Grenade>().SetDirection(transform.forward);
            newGrenade.GetComponent<Basic_Red_Grenade>().SetOwnerTag(gameObject.tag);

        }

    }

    public void damage(int damage)
    {
        _lives =  _lives -= damage;
        health.value = _lives;
        if (_lives < 1)
        {
            Destroy(this.gameObject,1.0f);
            AudioSource.PlayClipAtPoint(_deathSoundClip, new Vector3(2.8f, 21.81f, -26.97f));
  
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, direction * 50);
    }

}
