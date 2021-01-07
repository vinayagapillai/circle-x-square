using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject sceneCamera;

    private void Start()
    {
        float randomValue = Random.Range(-2f, 2f);
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(randomValue, this.transform.position.y), Quaternion.identity, 0);
        sceneCamera.SetActive(false);
    }


}
