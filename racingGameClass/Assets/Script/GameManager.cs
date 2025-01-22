using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inGameGroup;
    [SerializeField] private GameObject EndCanvas;
    void Update()
    {
        if (PlayerInfo.hp <= 0)
        {
            inGameGroup.SetActive(false);
            EndCanvas.SetActive(true);
            PlayerInfo.InitializeHP();
        }
    }
}
