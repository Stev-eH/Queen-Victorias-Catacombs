using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class RockMover : MonoBehaviour
{
    public bool isMoveable;
    public bool directionLocked;
    public float moveTime = 0.5f;
    private float moveTimer = 0f;

    private bool lockUp;
    private bool lockDown;
    private bool lockLeft;
    private bool lockRight;

    private enum direction
    {No, Left, Right, Up, Down }

    private direction moveDir = direction.No;
    private Vector3 destination;

    private AudioSource push;

    // Start is called before the first frame update
    void Start()
    {
        isMoveable= true;
        directionLocked = false;
        destination = transform.position;
        push = this.GetComponent<AudioSource>();
        lockUp = lockDown = lockLeft = lockRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!directionLocked)
        {
            if (moveDir == direction.Up)
            {
                destination = transform.position;
                destination += Vector3.up;
                directionLocked = true;
            }
            else if (moveDir == direction.Down)
            {
                destination = transform.position;
                destination += Vector3.down;
                directionLocked = true;
            }
            else if (moveDir == direction.Left)
            {
                destination = transform.position;
                destination += Vector3.left;
                directionLocked = true;
            }
            else if (moveDir == direction.Right)
            {
                destination = transform.position;
                destination += Vector3.right;
                directionLocked = true;
            }
            else
            {

            }
        }

        if(transform.position != destination)
        {


            if(moveDir == direction.Up)
            {
                transform.position += Vector3.up * Time.deltaTime * 2;
                if(transform.position.y > destination.y)
                {
                    transform.position = destination;
                    directionLocked = false;
                    isMoveable= true;
                    moveDir = direction.No;
                }
            }
            else if(moveDir == direction.Down)
            {
                transform.position += Vector3.down * Time.deltaTime * 2;
                if (transform.position.y < destination.y)
                {
                    transform.position = destination;
                    directionLocked = false;
                    isMoveable = true;
                    moveDir = direction.No;
                }
            }
            else if(moveDir == direction.Left)
            {
                transform.position += Vector3.left * Time.deltaTime * 2;
                if (transform.position.x < destination.x)
                {
                    transform.position = destination;
                    directionLocked = false;
                    isMoveable = true;
                    moveDir = direction.No;
                }
            }
            else if(moveDir == direction.Right)
            {
                transform.position += Vector3.right * Time.deltaTime * 2;
                if (transform.position.x > destination.x)
                {
                    transform.position = destination;
                    directionLocked = false;
                    isMoveable = true;
                    moveDir = direction.No;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {

            Vector3 dir = (collision.gameObject.transform.position - gameObject.transform.position).normalized;

            if (Mathf.Abs(dir.y) > 0.7f)
            {
                if (dir.x < 0)
                {
                    lockLeft = true;
                    Debug.Log("Left locked");
                }
                else if (dir.x > 0)
                {
                    lockRight = true;
                    Debug.Log("Right locked");
                }
            }
            else
            {
                if (dir.y < 0)
                {
                    lockDown = true;
                    Debug.Log("Down locked");
                }
                else if (dir.y > 0)
                {
                    lockUp = true;
                    Debug.Log("Up locked");
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!collision.gameObject.tag.Equals("Wall"))
            moveTimer += Time.deltaTime;

            Vector3 dir = (collision.gameObject.transform.position - gameObject.transform.position).normalized;

            if (isMoveable)
            {
                if (Mathf.Abs(dir.y) < 0.2f)
                {
                    if (dir.x > 0)
                    {
                        if (moveTimer > moveTime && !lockLeft)
                        {
                            isMoveable = false;
                            moveDir = direction.Left;
                            moveTimer = 0f;
                            push.Play();
                        }
                    }
                    else if (dir.x < 0)
                    {
                        if (moveTimer > moveTime && !lockRight)
                        {
                            isMoveable = false;
                            moveDir = direction.Right;
                            moveTimer = 0f;
                            push.Play();
                        }
                    }
                }
                else
                {
                    if (dir.y > 0)
                    {
                        if (moveTimer > moveTime && !lockDown)
                        {
                            isMoveable = false;
                            moveDir = direction.Down;
                            moveTimer = 0f;
                            push.Play();
                        }
                    }
                    else if (dir.y < 0)
                    {
                        if (moveTimer > moveTime  &&!lockUp)
                        {
                            isMoveable = false;
                            moveDir = direction.Up;
                            moveTimer = 0f;
                            push.Play();
                        }
                    }
                }
            }

    }

    private void OnCollisionExit(Collision collision)
    {
        moveTimer = 0f;

        if (collision.gameObject.tag.Equals("Wall"))
        {

            Vector3 dir = (collision.gameObject.transform.position - gameObject.transform.position).normalized;

            if (Mathf.Abs(dir.y) > 0.7f)
            {
                if (dir.x < 0)
                {
                    lockLeft = false;
                    Debug.Log("Left released");
                }
                else if (dir.x > 0)
                {
                    lockRight = false;
                    Debug.Log("Right released");
                }
            }
            else
            {
                if (dir.y < 0)
                {
                    lockDown = false;
                    Debug.Log("Down released");
                }
                else if (dir.y > 0)
                {
                    lockUp = false;
                    Debug.Log("Up released");
                }
            }
        }
    }
}
