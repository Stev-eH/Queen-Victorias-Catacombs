using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RoomTransition;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public entry direction;
    public int roomNumber;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.tag.Equals("Door"))
            GameObject.FindGameObjectWithTag("Logic").GetComponent<RoomTransition>().recieveTransition(direction, roomNumber);
    }
}
