using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly string[] idleDirections = { "Idle N", "Idle NW", "Idle W", "Idle SW", "Idle S", "Idle SE", "Idle E", "Idle NE" };
    private static readonly string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };
    private Animator animator;
    private int lastDirection;
    private Rigidbody2D rbody;
    public float speed = 1f;
    public Vector2 move;
    public float playerHealth = 100;
    public float playerTurbo = 100;


    public float fadeInTime = 1f;
    public float fadeOutTime = 1f;
    public float fadeDelay = 0.3f;
    public bool collided;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;
        
        if (move == Vector2.zero)
        {
            directionArray = idleDirections;
        }

        else
        {
            directionArray = runDirections;
           
        }

        lastDirection = DirectionToIndex(direction, 8);
        animator.Play(directionArray[lastDirection]);
 
    }



    public static int DirectionToIndex(Vector2 direction, int sliceCount)
    {
       
        Vector2 normDir = direction.normalized;
       
        float step = 360f / sliceCount;
       
        float halfstep = step / 2;
      
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
       
        angle += halfstep;
       
        if (angle < 0)
        {
            angle += 360;
        }
     
        float stepCount = angle / step;
     
        return Mathf.FloorToInt(stepCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        move = inputVector * speed;
        Vector2 currentPos = rbody.position;
        Vector2 newPos = currentPos + move * Time.deltaTime;
        rbody.MovePosition(newPos);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

   
        
    }


    public IEnumerator ColorLerpIn(PlayerController player, Color endColor)
    {

        Color startingColor = player.GetComponent<SpriteRenderer>().color;
        float t = 0;
        while (t < fadeInTime)
        {
            yield return new WaitForSeconds(t);
            player.GetComponent<SpriteRenderer>().color = Color.Lerp(startingColor, endColor, t / fadeInTime);
            t += Time.deltaTime;
        }
        player.GetComponent<SpriteRenderer>().color = endColor;
        yield return new WaitForSeconds(fadeDelay);
        StartCoroutine(ColorLerpOut(player, endColor, startingColor));
    }

    public IEnumerator ColorLerpOut(PlayerController player, Color startColor, Color endColor)
    {
        float t = 0;
        while (t < fadeOutTime)
        {
            yield return new WaitForSeconds(t);
            player.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, t / fadeOutTime);
             t += Time.deltaTime;
        }
        player.GetComponent<SpriteRenderer>().color = endColor;
    }
}
