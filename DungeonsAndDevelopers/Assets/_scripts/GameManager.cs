using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController[] PlayerControllers;

    int _activeTurnIndex;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerControllers.Length; i++)
        {
            PlayerControllers[i].RollInitiative();
            Debug.Log($"Iniative for Player {PlayerControllers[i].Id} = {PlayerControllers[i].Initiative}");
        }
        Array.Sort(PlayerControllers, new Comparison<PlayerController>((i1, i2) => i2.Initiative.CompareTo(i1.Initiative)));


        //Array.Reverse(PlayerControllers);
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("StartTurn"))
        {
            PlayerControllers[_activeTurnIndex].StartTurn();
            if (++_activeTurnIndex >= PlayerControllers.Length)
                _activeTurnIndex = 0;
        }
    }
}
