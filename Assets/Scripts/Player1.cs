using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

    [SerializeField]
    private Wall wall;
    [SerializeField]
    private float _mSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("Wall").GetComponent<Wall>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizonalInput = Input.GetAxis("Horizontal");
        float verticalInput =  Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizonalInput, 0, verticalInput);

        transform.Translate(direction * _mSpeed * Time.deltaTime);
    }
}
