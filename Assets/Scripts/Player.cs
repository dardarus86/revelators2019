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




    // Start is called before the first frame update
    void Start()
    {

      if (gameObject.tag == "Player1" || gameObject.tag == "Player2")
        {
           this.transform.position = new Vector3(Random.Range(-1.1f, 4.0f), 0.75f, Random.Range(-0.2f, -7.0f));
        }
        if (gameObject.tag == "Player3" || gameObject.tag == "Player4")
        {
            this.transform.position = new Vector3(Random.Range(7.37f, 13.3f), 3.75f, Random.Range(-0.63f, -6.1f));
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
            if (Input.GetKey(KeyCode.Joystick1Button6) && Time.time > _cantFire)
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
        print("load grenade function");
        _cantFire = Time.time + _fireRate;
        if (_team == "Blue")
        {
            print(" Blue team");
            GameObject newGrenade = Instantiate(_blueGrenadePrefab, transform.position, Quaternion.identity);
            print(" instantiated");
            newGrenade.GetComponent<Basic_Grenade_Blue>().SetDirection(transform.forward);
            newGrenade.GetComponent<Basic_Grenade_Blue>().SetOwnerTag(gameObject.tag);
            print(" set direction and set tag");

        }

        else if (_team == "Red")
        {
            GameObject newGrenade = Instantiate(_redGrenadePrefab, transform.position + transform.forward, Quaternion.identity);
            newGrenade.GetComponent<Basic_Grenade_Red>().SetDirection(transform.forward);
            newGrenade.GetComponent<Basic_Grenade_Red>().SetOwnerTag(gameObject.tag);

        }

    }

    public void damage()
    {
        _lives--;
        health.value = _lives;
        if (_lives < 1)
        {
            Destroy(this.gameObject,1.0f);
            AudioSource.PlayClipAtPoint(_deathSoundClip, new Vector3(2.8f, 21.81f, -26.97f));
  
        }
    }



}
