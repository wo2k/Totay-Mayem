using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    enum playerNum {PlayerOne, PlayerTwo, PlayerThree, PlayerFour};

    // Start is called before the first frame update
    void Start()
    {
        #region Add Player Indicator
        playerNum player = playerNum.PlayerOne;

        foreach (playerNum item in Enum.GetValues(typeof(playerNum)))
        {
            if (item == player)
            {
               
                int index = Array.IndexOf(Enum.GetValues(typeof(playerNum)), item) + 1;
                GameObject playerIndicator = (GameObject)Instantiate(Resources.Load("Prefabs/Player" + index + "Indicator"), Vector3.zero, Quaternion.identity, transform);
                playerIndicator.name = "Player" + index + "Indicator";
                playerIndicator.transform.localPosition = new Vector3(0, 0.6f, 0);
            }
        }
        #endregion

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
