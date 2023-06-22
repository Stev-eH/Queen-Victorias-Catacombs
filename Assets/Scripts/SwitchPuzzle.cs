using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzle : MonoBehaviour
{
    private GameObject[] switches;

    private bool isSolved;
    private int neededToSolve = 6;
    private int solved = 0;

    // Start is called before the first frame update
    void Start()
    {
        switches = GameObject.FindGameObjectsWithTag("Switch");
        isSolved= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSolved)
        {
            foreach (GameObject sw in switches)
            {
                if (sw.GetComponent<SwitchScript>().getId() == 0 && sw.GetComponent<SwitchScript>().getState() == false)
                {
                    solved++;
                }
                else if (sw.GetComponent<SwitchScript>().getId() == 1 && sw.GetComponent<SwitchScript>().getState() == true)
                {
                    solved++;
                }
                else if (sw.GetComponent<SwitchScript>().getId() == 2 && sw.GetComponent<SwitchScript>().getState() == false)
                {
                    solved++;
                }
                else if (sw.GetComponent<SwitchScript>().getId() == 3 && sw.GetComponent<SwitchScript>().getState() == true)
                {
                    solved++;
                }
                else if (sw.GetComponent<SwitchScript>().getId() == 4 && sw.GetComponent<SwitchScript>().getState() == false)
                {
                    solved++;
                }
                else if (sw.GetComponent<SwitchScript>().getId() == 5 && sw.GetComponent<SwitchScript>().getState() == true)
                {
                    solved++;
                }
                else
                {
                    solved = 0;
                }
                Debug.Log("Solved: " + solved);
            }
        }

        if(solved >= neededToSolve)
        {
            if(!isSolved)
            {
                solveRoom();
            }
            isSolved = true;
            Debug.Log("Solved!");
        }
    }

    public void solveRoom()
    {
        GameObject.FindGameObjectWithTag("Logic").GetComponent<SolvedPuzzles>().solveRoom(1);
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        if (doors.Length > 0)
        {
            foreach (GameObject d in doors)
            {
                Destroy(d);
            }
        }
    }

}
