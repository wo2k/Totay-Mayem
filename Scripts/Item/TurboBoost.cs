using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboBoost : ItemTemplate<TurboBoost>
{
    //CLASS SUMMARY: Item pickup Turbo Boost increases the player's Turbo upon trigger based off of designated "points" amount indicated in the inspector.

    public Color postProcessingColor;

    public override void ItemEffect(PlayerController player, float itemPoints)
    {
        player.playerTurbo = IncreasePoints(player.playerTurbo, itemPoints);
        player.StartCoroutine(player.ColorLerpIn(player, postProcessingColor));
        // PostProcessing.instance.StartCoroutine(PostProcessing.instance.ColorLerpIn(postProcessingColor));
    }

}
