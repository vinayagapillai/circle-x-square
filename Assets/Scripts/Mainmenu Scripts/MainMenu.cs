using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioClip theme;
    [HideInInspector]
    public AudioSource s;

    public GameObject menu;
    public GameObject multiplayerMenu;

    public string versionName = "0.1";
    public GameObject joinGameTF;
    public GameObject createGameTF;

    private void Awake()
    {
        s = gameObject.AddComponent<AudioSource>();
        s.clip = theme;
        s.loop = true;
        s.Play();
        DontDestroyOnLoad(gameObject);


        PhotonNetwork.ConnectUsingSettings(versionName);
    }

    public void SinglePlayer()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MultiPlayer()
    {
        menu.SetActive(false);
        multiplayerMenu.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        //Debug.Log("Connected");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createGameTF.name, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(joinGameTF.name, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("multiplayerArena");
    }


}
