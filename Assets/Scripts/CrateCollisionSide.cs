using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollisionSide : MonoBehaviour
{
    public string side;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
            gameObject.GetComponentInParent<RockMover>().recieveCollisionPlayer(side);
        else if(collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Crate"))
            gameObject.GetComponentInParent<RockMover>().recieveCollisionWall(side);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
            gameObject.GetComponentInParent<RockMover>().recieveCollisionPlayer(side);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Crate"))
        {
            gameObject.GetComponentInParent<RockMover>().recieveCollisionWall(side);
        }
    }
}
