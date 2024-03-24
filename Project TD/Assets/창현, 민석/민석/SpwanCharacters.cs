using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Linq;
using Photon.Realtime;

public class SpwanCharacters : MonoBehaviour
{
    public GameObject character;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(character.name, spawnPoints[PhotonNetwork.CountOfPlayers - 1].position, spawnPoints[PhotonNetwork.CountOfPlayers - 1].rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
