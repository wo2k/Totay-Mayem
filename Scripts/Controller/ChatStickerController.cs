using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChatStickerController : MonoBehaviour
{

    public Queue instanstiatedStickers = new Queue();
    public Queue chatLogList = new Queue();

    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void InstanstiateLog(GameObject sticker)
    {
        if(chatLogList.Count >= 5)
        {
            Destroy((GameObject)chatLogList.Dequeue());
        }

        if(chatLogList.Count >= 1)
        {
            Destroy((GameObject)chatLogList.Dequeue());
        }
        GameObject chatLog = (GameObject)Instantiate(Resources.Load("Prefabs/ChatSticker/Log/Log"), FindObjectOfType<ChatStickerController>().transform.GetChild(9));
        chatLog.transform.GetChild(0).GetComponent<Image>().sprite = sticker.GetComponent<SpriteRenderer>().sprite;
        chatLogList.Enqueue(chatLog);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.inputString != "")
        {
            int number;
            bool isNumber = Int32.TryParse(Input.inputString, out number);

            if(isNumber && number >= 0 && number < 10)
            {
                foreach(var item in LoadOutManager.instance.stickerSprite)
                {
                    if(LoadOutManager.instance.stickerSprite.IndexOf(item) == number - 1)
                    {
                        if (instanstiatedStickers.Count >= 1)
                        {
                            Destroy((GameObject)instanstiatedStickers.Dequeue());
                            GameObject chatSticker = Instantiate(item, FindObjectOfType<PlayerManager>().transform);
                            instanstiatedStickers.Enqueue(chatSticker);
                            InstanstiateLog(chatSticker);
                        }
                        else
                        {
                            GameObject chatSticker = Instantiate(item, FindObjectOfType<PlayerManager>().transform);
                            instanstiatedStickers.Enqueue(chatSticker);
                            InstanstiateLog(chatSticker);
                        }
                    }
                }
               
            }
        }
    }
}
