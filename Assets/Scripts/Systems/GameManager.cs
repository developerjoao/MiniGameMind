using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Game Manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public TextMeshProUGUI[] coinText = new TextMeshProUGUI[3];
    int[] coinValues = new int[3] {0,0,0};

    void Start()
    {
        coinText[0].text = coinValues[0].ToString();
        coinText[1].text = coinValues[1].ToString();
        coinText[2].text = coinValues[2].ToString();
    }

    public void CollectCoin(int value)
    {
        coinValues[value] += 1;
        coinText[value].text = coinValues[value].ToString();
    }
}
