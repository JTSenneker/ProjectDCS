using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<PlayerMovement> players = new List<PlayerMovement>();
    public GameObject playerPrefab;
    public int startingId = 0;

    // Start is called before the first frame update
    void Start()
    {
        players.Add(FindObjectOfType<PlayerMovement>());
        players[0].controllerId = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("JoinIn1")) {
            foreach (PlayerMovement player in players) {
                if (player.controllerId == 1) return;
            }
            AddPlayer(1);
        }
        if (Input.GetButtonDown("JoinIn2")) {
            foreach (PlayerMovement player in players) {
                if (player.controllerId == 2) return;
            }
            AddPlayer(2);
        }
    }

    void AddPlayer(int id) {
        Debug.Log("Player Joined.");
        GameObject obj = Instantiate(playerPrefab, transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
        PlayerMovement player = obj.GetComponent<PlayerMovement>();
        player.controllerId = id;
        players.Add(player);

        if(players.Count == 2) {
            players[0].eyes.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[1].eyes.GetComponent<Camera>().rect = new Rect(0, 0, 1, .5f);
        } else if (players.Count == 3) {
            players[0].eyes.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[1].eyes.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[2].eyes.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);
        } else if (players.Count == 4) {
            players[0].eyes.GetComponent<Camera>().rect = new Rect(0, .5f, .5f, .5f);
            players[1].eyes.GetComponent<Camera>().rect = new Rect(.5f, .5f, .5f, .5f);
            players[2].eyes.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[3].eyes.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);
        }
    }
}
