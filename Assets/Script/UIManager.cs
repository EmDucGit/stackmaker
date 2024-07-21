using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrickUI : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LevelSelectPanel;
    [SerializeField] TextMeshProUGUI textBrick;
    [SerializeField] TextMeshProUGUI textLevel;
    int currBrickInGame;
    private void Start()
    {
        ActionManager.OnStartLevel += SetUI;
        ActionManager.OnAddBrick += AddBrickUI;
        ActionManager.OnRemoveBrick += RemoveBrickUI;
        ActionManager.OnWinPos += ClearBrickUI;
        ActionManager.OnWinPos += SetUIOnWWin;
        currBrickInGame = 0;
        if (PlayerPrefs.HasKey("currBrickInGame"))
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt("currBrickInGame", currBrickInGame);
        }
    }

    void SetUI()
    {
        if(currBrickInGame <= 9)
        {
            textBrick.text = "0" + currBrickInGame.ToString();
        } else
        {
            textBrick.text = currBrickInGame.ToString();
        }
        textLevel.text = PlayerPrefs.GetString("currLevel");
    }


    void AddBrickUI()
    {
        currBrickInGame++;
        SetUI();
    }

    void RemoveBrickUI()
    {
        currBrickInGame--;
        SetUI();
    }

    void ClearBrickUI()
    {
        currBrickInGame = 0;
        SetUI();
    }
    void SetUIOnWWin()
    {
        WinPanel.SetActive(true);
    }

}
