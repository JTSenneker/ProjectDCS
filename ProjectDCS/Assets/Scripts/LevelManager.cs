using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public DungeonGen dungeon;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.spawnPoints = spawnPoints;
        GameManager.instance.AddPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
