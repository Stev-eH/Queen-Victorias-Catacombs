using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    private AudioSource click;

    void Start()
    {
        click = this.GetComponent<AudioSource>();    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("CrateInside"))
        {
            Debug.Log("Pressure plate activated!");
            click.Play();
            GameObject.FindGameObjectWithTag("Logic").GetComponent<SolvedPuzzles>().solveRoom(0);
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            if(doors.Length > 0 )
            {
                foreach(GameObject d in doors)
                {
                    Destroy(d);
                }
            }
        }
    }
}
