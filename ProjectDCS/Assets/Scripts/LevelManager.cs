using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public List<NavMeshSurface> navmeshsurfaces = new List<NavMeshSurface>();
    public Transform[] spawnPoints;
    public DungeonGen dungeon;


    public AudioClip levelMusic;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.spawnPoints = spawnPoints;
        GameManager.Instance.AddPlayers();
        foreach(NavMeshSurface Surface in navmeshsurfaces)
        {
            Surface.BuildNavMesh();
        }
        MusicManager.Instance.ChangeMusic(levelMusic);
    }
    void Start() {
     
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
