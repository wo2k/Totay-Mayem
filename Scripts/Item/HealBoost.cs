using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBoost : ItemTemplate<HealBoost>
{
    //CLASS SUMMARY: Item pickup Heal Boost heals the player upon trigger based off of designated "points" amount indicated in the inspector.
    public Color postProcessingColor;

    public override void ItemEffect(PlayerController player, float itemPoints)
    {
        player.playerHealth = IncreasePoints(player.playerHealth, itemPoints);
        player.StartCoroutine(player.ColorLerpIn(player, postProcessingColor));
        // PostProcessing.instance.StartCoroutine(PostProcessing.instance.ColorLerpIn(postProcessingColor));
    }

}
