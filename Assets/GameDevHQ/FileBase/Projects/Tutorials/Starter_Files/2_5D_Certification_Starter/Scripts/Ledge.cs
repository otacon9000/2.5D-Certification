using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    [SerializeField]
    private Vector3 _handsPosition, _standPosition;
    [SerializeField]
    private Transform _handPos, _standPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LedgeChecker"))
        {
            Player player = other.transform.parent.GetComponent<Player>();

            if (player != null)
            {
                //player.GrabLedge(_handsPosition, this);
                player.GrabLedge(_handPos.position, this);
            }
        }
    }

    public Vector3 GetStandPosition()
    {
        //return _standPosition;
        return _standPos.position;
    }
}
