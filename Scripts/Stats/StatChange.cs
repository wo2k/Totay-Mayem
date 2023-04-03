using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatChange : MonoBehaviour
{
    //CLASS SUMMARY: This class plays the purpose of interacting with player stat points. I.E: Player Health, Turbo and Kill Streak.

    public float IncreasePoints(float playerPoints, float points)
    {
        return playerPoints + points;
    }

    public float DecreasePoints(float playerPoints, float points)
    {
        return playerPoints - points;
    }

}
