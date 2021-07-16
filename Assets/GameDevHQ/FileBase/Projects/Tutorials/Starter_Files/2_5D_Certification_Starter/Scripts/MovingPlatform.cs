using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    [SerializeField]
    private float _speed = 1.0f;
    private bool _switching = true;



    // Update is called once per frame
    void FixedUpdate()
    {
        if(_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, Time.deltaTime * _speed);
        }
        else if (_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, Time.deltaTime * _speed);
        }

        if (transform.position == _pointB.position)
        {
            _switching = false;
        }
        else if (transform.position == _pointA.position)
        {
            _switching = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;

        }
    }
}
