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

    int playerHeartIndex = 2;
    public GameObject[] playerHeart = new GameObject[3];
    public TextMeshProUGUI[] coinText = new TextMeshProUGUI[3];
    int[] coinValues = new int[3] {0,0,0};

    void Start()
    {
        coinText[0].text = coinValues[0].ToString();
        coinText[1].text = coinValues[1].ToString();
        coinText[2].text = coinValues[2].ToString();

        FreezeTime();
        playerObject.DisableMovement();
    }

    public void CollectCoin(int value)
    {
        coinValues[value] += 1;
        coinText[value].text = coinValues[value].ToString();
    }

    public void UpdateHeart(bool damage)
    {
        if(damage)
        {
            playerHeart[playerHeartIndex].SetActive(false);
            playerHeartIndex -= 1;
            if(playerHeartIndex == 0)
            {
                //die
            }
        }else{
            if(playerHeartIndex == 2)
            {
                return;
            }
            playerHeart[playerHeartIndex].SetActive(true);
            playerHeartIndex += 1;
        }
    }

    public GameObject tooltipMenu;
    public void DisableTooltipMenu()
    {
        tooltipMenu.SetActive(false);
        playerObject.EnableMovement();
        ResumeTime();
    }

    public void FreezeTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
    }

    public PlayerBehaviour playerObject;
}
