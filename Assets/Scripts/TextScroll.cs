using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScroll : MonoBehaviour
{
    public float textspeed;
    public float introTime;

    private void Start()
    {
        Invoke("StartGame", introTime);
    }
    void Update()
    {
        this.GetComponent<RectTransform>().position += new Vector3(0f, textspeed * Time.deltaTime, 0f);

        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
