using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvedPuzzles : MonoBehaviour
{
    public bool room0Solved = false;
    public bool room1Solved = false;
    public bool room2Solved = false;
    public bool room3Solved = false;
    public bool room7Solved = false;
    public bool key1Used = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void solveRoom(int roomNumber)
    {
        if(roomNumber == 0)
        {
            room0Solved = true;
        }
        if(roomNumber == 1)
        {
            room1Solved = true;
        }
        if(roomNumber == 2)
        {
            room2Solved = true;
        }
        if (roomNumber == 3)
        {
            room3Solved = true;
        }
        if (roomNumber == 7)
        {
            room7Solved = true;
        }
    }

    public bool getRoomStatus(int roomNumber)
    {
        if (roomNumber == 0)
        {
            return room0Solved;
        }
        if (roomNumber == 1)
        {
            return room1Solved;
        }
        if (roomNumber == 2)
        {
            return room2Solved;
        }
        if (roomNumber == 3)
        {
            return room3Solved;
        }
        if(roomNumber == 7)
        {
            return room7Solved;
        }

        return false;
    }

    public bool getKeyStatus(int roomNumber)
    {
        if (roomNumber == 0)
        {
            return key1Used;
        }

        return false;
    }

    public void solveRoomKey(int roomNumber)
    {
        if (roomNumber == 0)
        {
            key1Used= true;
        }
    }
}
