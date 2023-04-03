using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform characterTransform;
    public Vector3 startingPos;
    public Vector3 targetPos;
    public float camSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterTransform = FindObjectOfType<PlayerController>().transform;
        startingPos = characterTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(characterTransform != null)
        {
            targetPos = new Vector3(characterTransform.position.x, characterTransform.position.y, transform.position.z);
            Vector3 velocity = (targetPos - transform.position) * camSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
    }
}
