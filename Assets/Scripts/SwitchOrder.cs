using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOrder : MonoBehaviour
{
    public bool failure;

    private bool firstRight = false;
    private bool secondRight = false;

    // Start is called before the first frame update
    void Start()
    {
        failure= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!failure)
        {
            GameObject[] switches = GameObject.FindGameObjectsWithTag("Switch");

            foreach (GameObject sw in switches)
            {
                SwitchScript script = sw.GetComponent<SwitchScript>();
                if (!firstRight)
                {
                    if (script.getId() == 1 && script.getState() == false)
                    {
                        firstRight = true;
                    }
                    else if (((script.getId() == 2 && script.getState() == false) || (script.getId() == 3 && script.getState() == false)))
                    {
                        failure = true;
                    }
                }
                else
                {
                    if(!secondRight)
                    {
                        if(script.getId() == 3 && script.getState() == false)
                            secondRight= true;
                        else if(script.getId() == 2 && script.getState() == false)
                            failure= true;
                    }
                    else
                    {
                        if (script.getId() == 2 && script.getState() == false)
                            GameObject.FindGameObjectWithTag("Logic").GetComponent<SolvedPuzzles>().solveRoom(7);
                    }
                }
            }
        }

        else
        {
            Invoke("Reset", 2f);
        }
    }

    public void Reset()
    {
        GameObject[] switches = GameObject.FindGameObjectsWithTag("Switch");

        foreach (GameObject sw in switches)
        {
            SwitchScript script = sw.GetComponent<SwitchScript>();
            script.isUp = true;
            failure = false;
        }
    }

}
