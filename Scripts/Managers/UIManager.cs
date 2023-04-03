using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonTemplate<UIManager>
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject hud = (GameObject)Instantiate(Resources.Load("Prefabs/HUD"), Vector3.zero, Quaternion.identity, transform);
        hud.GetComponent<Canvas>().worldCamera = Camera.main;

        #region Add Chat Sticker Inventory

        foreach(var item in LoadOutManager.instance.chatStickerInventory)
        {
            GameObject chatSticker = Instantiate(item, FindObjectOfType<ChatStickerController>().transform.GetChild(LoadOutManager.instance.chatStickerInventory.IndexOf(item)));
            chatSticker.transform.SetSiblingIndex(0);
        }
        

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
