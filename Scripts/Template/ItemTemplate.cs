using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This abstract class plays a role of being a template for all item pickups in game. Upon trigger, it will product an effect.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ItemTemplate<T> : StatChange where T : Component
{
   

    //Determines the amount of points the item will increase or decrease
    public float point;
    public GameObject spawner;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemEffect(collision.GetComponent<PlayerController>(), point);
        GameObject particleEffect = (GameObject)Instantiate(Resources.Load("Prefabs/Particles/ItemPickupEfx"), spawner.transform);
        particleEffect.transform.position = Vector3.zero;
        particleEffect.transform.position = transform.position;
        particleEffect.transform.GetChild(0).transform.localPosition = Vector3.zero;
        Destroy(gameObject.transform.parent.gameObject);
    }

    //Default function for ItemEffect that can be over written
    public virtual void ItemEffect(PlayerController player, float itemPoints)
    {
        player.playerHealth = DecreasePoints(player.playerHealth, itemPoints);        
    }
}
