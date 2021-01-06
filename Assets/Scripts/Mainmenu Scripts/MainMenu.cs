using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioClip theme;
    [HideInInspector]
    public AudioSource s;

    private void Awake()
    {
        s = gameObject.AddComponent<AudioSource>();
        s.clip = theme;
        s.loop = true;
        s.Play();
        DontDestroyOnLoad(gameObject);
    }

    public void SinglePlayer()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MultiPlayer()
    {
        //SceneManager.LoadScene("SampleScene");
    }
}
