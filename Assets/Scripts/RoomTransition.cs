using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    public enum entry
    {Invalid, Up, Down, Left, Right }

    entry direction = entry.Invalid;


    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Logic").Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recieveTransition(entry direction, int roomNumber)
    {
        this.direction = direction;
        SceneManager.LoadScene(roomNumber);
    }

    public entry passTransition()
    {
        return direction;
    }
}
