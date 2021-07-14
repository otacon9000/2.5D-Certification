using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UIManager is NULL");
            return _instance;
        }
    }
    [SerializeField]
    private Text _coinText, _livesText;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateCoinScore(int coins)
    {

        _coinText.text = "Coins: " + coins.ToString();
    }

    public void UpdateLives(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
