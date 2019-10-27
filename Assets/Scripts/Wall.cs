using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField]
    private float _speed = 0.2f;
    private float _multiplier = 0.02f;
    private float _Timer = 0.0f;
    public float MaxTime = 100000.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, _speed, 0) * Time.deltaTime);
        //_speed = _speed + _multiplier;
        _Timer += Time.deltaTime;
        _speed = Mathf.Lerp(0.2f, 50.0f, _Timer / MaxTime);
    }
}
