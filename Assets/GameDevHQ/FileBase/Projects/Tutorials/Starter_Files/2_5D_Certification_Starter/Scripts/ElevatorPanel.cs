using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private Renderer _screenMat;
    [SerializeField]
    private int _requireCoins = 8;
    private Elevator _elevator;
    private bool _elevatorCalled = false;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator_Lift").GetComponentInChildren<Elevator>();

        if (_elevator == null)
        {
            Debug.LogError("Elevator is NULL");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (Input.GetKey(KeyCode.E)/* && player.GetCoinValue() >= _requireCoins*/)
                {
                    _screenMat.material.color = Color.green;
                    if (_elevatorCalled == true)
                    {
                        _elevatorCalled = false;
                        _screenMat.material.color = Color.red;
                    }
                    else
                    {
                        _screenMat.material.color = Color.red;
                        
                    }
                    _elevator.CallElevator();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Elevator")
        {
            _screenMat.material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Elevator")
        {
            _screenMat.material.color = Color.red;
        }
    }

}
