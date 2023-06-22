using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvedRoom : MonoBehaviour
{
    public int roomNumber;

    private bool solvedStatus;

    // Start is called before the first frame update
    void Start()
    {
        solvedStatus = checkSolvedStatus();
        if(solvedStatus)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        solvedStatus = checkSolvedStatus();
        if (solvedStatus)
        {
            Destroy(this.gameObject);
        }
    }

    bool checkSolvedStatus()
    {
        return GameObject.FindGameObjectWithTag("Logic").GetComponent<SolvedPuzzles>().getRoomStatus(roomNumber);
    }
}
