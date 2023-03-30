using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonDebugInfo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PhotonView photonView = GetComponent<PhotonView>();
        PhotonNetwork.OfflineMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
