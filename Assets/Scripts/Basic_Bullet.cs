using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    private Vector3 direction;
 

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(direction * _speed * Time.deltaTime);
        Destroy(this.gameObject, 2);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
