using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DungeonGen : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public int enemyAmount = 10;


    public int cols = 5;
    public int rows = 5;

    public float roomW = 50;
    public float roomH = 50;

    public GameObject[] roomPrefabs;


    // Start is called before the first frame update
    void Awake()
    {
        for (int x = 0; x < cols; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                GameObject randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Length)];

                GameObject room = Instantiate(randomRoom, new Vector3(x * (roomW), 0, y * (roomH)), Quaternion.identity);
                FindObjectOfType<LevelManager>().navmeshsurfaces.Add(room.GetComponent<NavMeshSurface>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        //for(int i = 0; i < roomPrefabs.Count; i++)
        {

        }
    }

}
