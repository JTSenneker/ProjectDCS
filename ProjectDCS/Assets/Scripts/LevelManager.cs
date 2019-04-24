using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public DungeonGen dungeon;
    public NavMeshBuildSettings navMeshSettings;
    public List<NavMeshBuildSource> sources;
    public Bounds navMeshBounds;
    public Vector3 navMeshPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.spawnPoints = spawnPoints;
        //GenerateNavMesh();
        GameManager.instance.AddPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateNavMesh()
    {
        NavMeshBuilder.BuildNavMeshData(navMeshSettings, sources, navMeshBounds, navMeshPosition, Quaternion.identity);
    }
}
