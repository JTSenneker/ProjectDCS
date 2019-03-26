using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerManager : MonoBehaviour
{
    Player player;
    public int controllerID = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(controllerID);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Join")) {
            GameManager.instance.AddPlayer(controllerID);
        }
    }
}
