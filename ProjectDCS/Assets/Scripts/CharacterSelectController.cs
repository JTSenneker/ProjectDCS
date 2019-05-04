using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rewired;
using UnityEngine.SceneManagement;

public class CharacterSelectController : MonoBehaviour
{
    public GameObject JoinMenu;
    public GameObject characterMenu;
    public GameObject readyScreen;

    public TextMeshProUGUI classNameText;
    public RawImage characterPortrait;

    public RenderTexture[] characterRenderTextures;

    public int playerID = 0;

    private Player player;
    public GameObject[] characterPrefabs;
    private int characterIndex = 0;
    private bool allPlayersReady;
    public bool isReady { get; set; }

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
        if (characterMenu.activeInHierarchy && !isReady)
        {
            if (player.GetButtonDown("Horizontal"))
            {
                characterIndex++;
                if (characterIndex == characterPrefabs.Length) characterIndex = 0;
                characterPortrait.texture = characterRenderTextures[characterIndex];
                classNameText.text = characterPrefabs[characterIndex].name;
            }
            if (player.GetNegativeButtonDown("Horizontal"))
            {
                characterIndex--;
                if (characterIndex == -1) characterIndex = characterPrefabs.Length-1;
                characterPortrait.texture = characterRenderTextures[characterIndex];
                classNameText.text = characterPrefabs[characterIndex].name;
            }

            if (player.GetButtonDown("Select"))
            {
                ReadyUp(characterIndex);
            }
        }
        if (isReady)
        {
            List<CharacterSelectController> characterSelects = new List<CharacterSelectController>();
            characterSelects.AddRange(FindObjectsOfType<CharacterSelectController>());
            foreach(CharacterSelectController character in characterSelects)
            {
                if (character.JoinMenu.activeInHierarchy) continue;
                if (!character.isReady) return;
                else allPlayersReady = true;
            }
        }
        if (allPlayersReady)
        {
            if (player.GetButtonDown("Join"))
            {
                MusicManager.Instance.CallFadeOut(3);
                
                
            }
            if (MusicManager.Instance.audioSource.volume <= .01f)
            {
                SceneManager.LoadScene("MainDungeon");
            }
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
    void ReadyUp(int characterIndex)
    {
        isReady = true;
        GameManager.Instance.playerPrefabs.Insert(playerID,characterPrefabs[characterIndex]);
        GameManager.Instance.playerPrefabs.RemoveAt(playerID + 1);
        readyScreen.SetActive(true);
    }
}
