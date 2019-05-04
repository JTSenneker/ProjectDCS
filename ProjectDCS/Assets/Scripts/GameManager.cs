using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

using UnityStandardAssets.Characters.FirstPerson;

public enum RespawnType {
    ATPLAYER, ATPOS
}


public class GameManager : MonoBehaviour
{
    
    public RespawnType respawnType;
    public Transform[] spawnPoints;

    public static GameManager Instance;
    public List<GameObject> playerPrefabs = new List<GameObject>();
    public List<FirstPersonController> players = new List<FirstPersonController>();
    public GameObject playerPrefab;
    public int startingId = 0;
    public Vector3 respawnPos = new Vector3(0, 0, 0);
    public Quaternion respawnRot = new Quaternion(0, 0, 0, 0);

    void Awake() {
        //if we don't already have an instance of this class
        if (Instance == null)
        {
            //assign this particular instance of the script to the instance property
            Instance = this;
            DontDestroyOnLoad(gameObject);//once we've done this, tell us not to destroy this object when loading a new scene
        }
        else//if there's already an instance of this script we want to destroy this object
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < 4; i++)
        {
            playerPrefabs.Add(playerPrefab);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //players.Add(FindObjectOfType<PlayerMovement>());
        //players[0].controllerId = 0;
    }

    // Update is called once per frame
 
    /// <summary>
    /// Adds all players that have joined from the character select screen
    /// </summary>
    public void AddPlayers()
    {
        //foreach (GameObject obj in playerPrefabs) {
        //    if (obj.GetComponent<FirstPersonController>() == null) playerPrefabs.Remove(obj);
        //}
        for (int i = 0; i < playerPrefabs.Count; i++)
        {
            if (playerPrefabs[i].GetComponent<FirstPersonController>() != null)
            {
                if (playerPrefabs[i].GetComponent<FirstPersonController>() != null) {
                    GameObject playerGO = Instantiate(playerPrefabs[i], spawnPoints[i].position, Quaternion.identity);
                    playerGO.GetComponent<FirstPersonController>().controllerId = i;
                    players.Add(playerGO.GetComponent<FirstPersonController>());
                }
            }
        }
        print(players.Count);
        if (players.Count == 2)
        {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, 1, .5f);
            players[0].UICam.rect = new Rect(0, .5f, 1, .5f);
            players[1].UICam.rect = new Rect(0, 0, 1, .5f);
        }
        else if (players.Count == 3)
        {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[2].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);

            players[0].UICam.rect = new Rect(0, .5f, 1, .5f);
            players[1].UICam.rect = new Rect(0, 0, .5f, .5f);
            players[2].UICam.rect = new Rect(.5f, 0, .5f, .5f);
        }
        else if (players.Count == 4)
        {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, .5f, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, .5f, .5f, .5f);
            players[2].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[3].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);

            players[0].UICam.rect = new Rect(0, .5f, .5f, .5f);
            players[1].UICam.rect = new Rect(.5f, .5f, .5f, .5f);
            players[2].UICam.rect = new Rect(0, 0, .5f, .5f);
            players[3].UICam.rect = new Rect(.5f, 0, .5f, .5f);
        }
    }

    public void AddPlayer(int id) {
       foreach(FirstPersonController p in players) {
            if (p.controllerId == id) return;
        }

        Debug.Log("Player Joined.");
        GameObject obj = new GameObject();
        switch (respawnType) {
            case RespawnType.ATPLAYER:
                obj = Instantiate(playerPrefab, transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                break;
            case RespawnType.ATPOS:
                obj = Instantiate(playerPrefab, respawnPos, respawnRot);
                break;
            default:
                break;
        }
        FirstPersonController player = obj.GetComponent<FirstPersonController>();
        player.controllerId = id;
        players.Add(player);
        Debug.Log(players.Count + " players now.");

        if(players.Count == 2) {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[0].UICam.rect = new Rect(0, .5f, 1, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, 1, .5f);
            players[1].UICam.rect = new Rect(0, 0f, 1, .5f);
        } else if (players.Count == 3) {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[0].UICam.rect = new Rect(0, .5f, 1, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[1].UICam.rect = new Rect(0, 0, .5f, .5f);
            players[2].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);
            players[2].UICam.rect = new Rect(.5f, 0, .5f, .5f);
        } else if (players.Count == 4) {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, .5f, .5f);
            players[0].UICam.rect = new Rect(0, .5f, .5f, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, .5f, .5f, .5f);
            players[1].UICam.rect = new Rect(.5f, .5f, .5f, .5f);
            players[2].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[2].UICam.rect = new Rect(0, 0, .5f, .5f);
            players[3].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);
            players[3].UICam.rect = new Rect(.5f, 0, .5f, .5f);
        }
    }
}
