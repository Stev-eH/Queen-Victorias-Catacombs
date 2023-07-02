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

    [SerializeField]
    private string collisionSide;

    [SerializeField]
    private string lockSide;

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


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
            moveTimer += Time.deltaTime;

        if (isMoveable)
        {


            if (collisionSide.Equals("Right"))
            {
                if (moveTimer > moveTime && !lockLeft)
                {
                    isMoveable = false;
                    moveDir = direction.Left;
                    moveTimer = 0f;
                    push.Play();
                    collisionSide = "";
                }
            }
            if (collisionSide.Equals("Left"))
            {
                if (moveTimer > moveTime && !lockRight)
                {
                    isMoveable = false;
                    moveDir = direction.Right;
                    moveTimer = 0f;
                    push.Play();
                    collisionSide = "";
                }
            }
            if (collisionSide.Equals("Down"))
            {
                if (moveTimer > moveTime && !lockUp)
                {
                    isMoveable = false;
                    moveDir = direction.Up;
                    moveTimer = 0f;
                    push.Play();
                    collisionSide = "";
                }
            }
            if (collisionSide.Equals("Up"))
            {
                if (moveTimer > moveTime && !lockDown)
                {
                    isMoveable = false;
                    moveDir = direction.Down;
                    moveTimer = 0f;
                    push.Play();
                    collisionSide = "";
                }
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        moveTimer = 0f;
    }


    public void recieveCollisionPlayer(string side)
    {
        collisionSide= side;
    }

    public void recieveCollisionWall(string side)
    {
        lockSide = side;
    }

    public void lockDir(string side)
    {
        if(side.Equals("Left"))
        {
            lockLeft = true;
        }
        if (side.Equals("Right"))
        {
            lockRight = true;
        }
        if (side.Equals("Up"))
        {
            lockUp= true;
        }
        if (side.Equals("Down"))
        {
            lockDown= true;
        }
    }

    public void unlockDir(string side)
    {
        if (side.Equals("Left"))
        {
            lockLeft = false;
        }
        if (side.Equals("Right"))
        {
            lockRight = false;
        }
        if (side.Equals("Up"))
        {
            lockUp = false;
        }
        if (side.Equals("Down"))
        {
            lockDown = false;
        }
    }
}
