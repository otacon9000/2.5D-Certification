using System.Data.Common;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private enum CollectableType
    {
        coin, 
        card
    }

    [SerializeField]
    private CollectableType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                switch(type)
                {
                    case(CollectableType.coin):
                    player.AddCoin();
                    break;
                    case(CollectableType.card):
                    player.AddCard();
                    break;
                    default:
                    Debug.Log("not a collectable type");
                    break;

                }
            }
            
            Destroy(this.gameObject );
        }
    }

}


