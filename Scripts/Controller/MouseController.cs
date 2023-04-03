using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{

    public Vector3 jsPos;
    public Image jsContainer;
    public Image joystick;
    public PlayerController character;
    public  Vector3 mousePos;
    public Texture2D cursor;

    // Start is called before the first frame update
    void Start()
    {
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        jsPos = Vector3.zero;
        character = FindObjectOfType<PlayerController>();
        Cursor.SetCursor(cursor, Vector2.zero, UnityEngine.CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(jsContainer.rectTransform, Input.mousePosition, Camera.main, out position);
        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);
        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        jsPos = new Vector3(x, y, 0);

        jsPos = (jsPos.magnitude > 1) ? jsPos.normalized : jsPos;

        joystick.rectTransform.anchoredPosition = new Vector3(jsPos.x * (jsContainer.rectTransform.sizeDelta.x / 3), jsPos.y * (jsContainer.rectTransform.sizeDelta.y / 3));
        character.SetDirection(jsPos);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
