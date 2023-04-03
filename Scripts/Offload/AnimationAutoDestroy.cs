using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAutoDestroy : MonoBehaviour
{

    public float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, GetComponent<Animation>().GetClipCount() + delay);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
