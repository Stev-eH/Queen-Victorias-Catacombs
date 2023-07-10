using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    private bool direction;
    private float changeTime;

    public int keyId;

    [SerializeField]
    private float changeTimer;

    private Transform goalPos;

    // Start is called before the first frame update
    void Start()
    {
        direction = true;
        changeTime = 1f;
        changeTimer = changeTime;

        goalPos = this.transform;
        goalPos.position += new Vector3(0f, 0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;

        if (direction)
        {
            goalPos.position -= new Vector3(0f, 0.2f * Time.deltaTime, 0f);
        }
        else
        {
            goalPos.position += new Vector3(0f, 0.2f * Time.deltaTime, 0f);
        }

        if (changeTime <= 0)
        {
            direction = !direction;
            changeTime = changeTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(9);
        }
    }
}
