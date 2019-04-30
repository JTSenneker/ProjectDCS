using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public List<NavMeshSurface> navmeshsurfaces = new List<NavMeshSurface>();
    public Transform[] spawnPoints;
    public DungeonGen dungeon;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.spawnPoints = spawnPoints;
        GameManager.instance.AddPlayers();
        foreach(NavMeshSurface Surface in navmeshsurfaces)
        {
            Surface.BuildNavMesh();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
