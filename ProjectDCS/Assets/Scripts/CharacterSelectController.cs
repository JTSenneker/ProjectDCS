using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rewired;

public class CharacterSelectController : MonoBehaviour
{
    public GameObject JoinMenu;
    public GameObject characterMenu;

    public TextMeshProUGUI classNameText;
    public RawImage characterPortrait;

    public RenderTexture[] characterRenderTextures;

    public int playerID = 0;

    private Player player;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Join"))
        {
            JoinGame();
        }
    }

    void JoinGame()
    {
        JoinMenu.SetActive(false);
        characterMenu.SetActive(true);
    }

    void LeaveGame()
    {
        JoinMenu.SetActive(true);
        characterMenu.SetActive(false);
    }
}
