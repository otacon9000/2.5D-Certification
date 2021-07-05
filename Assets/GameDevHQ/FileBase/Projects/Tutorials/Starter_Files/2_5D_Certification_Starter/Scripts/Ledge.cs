using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    [SerializeField]
    private Vector3 _handsPosition, _standPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LedgeChecker"))
        {
            Player player = other.transform.parent.GetComponent<Player>();

            if (player != null)
            {
                player.GrabLedge(_handsPosition, this);
            }
        }
    }

    public Vector3 GetStandPosition()
    {
        return _standPosition;
    }
}
