using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public AudioClip bell;
    public Image fade;
    public void StartGame()
    {
        AudioSource aS = GetComponent<AudioSource>();
        aS.Stop();
        aS.loop= false;
        aS.clip= bell;
        aS.Play();
        Invoke("LoadGame", 3);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(8);
    }
}
