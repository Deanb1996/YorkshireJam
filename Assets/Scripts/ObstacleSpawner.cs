using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject player;

    public int spawnChance1;
    public int spawnChance2;
    public int spawnChance3;

    List<GameObject> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<GameObject>();

        for (int i = 15; i < 175; i += 15)
        {
            int spawnPos = Random.Range(-4, 6);

            GameObject ob = Instantiate(obstacle1, new Vector3(spawnPos, -2.55f, player.transform.position.z + i), Quaternion.Euler(0, Random.Range(0, 180), 0));
            obstacles.Add(ob);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //  Delete if player has gone by it
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (player.transform.position.z > obstacles[i].transform.position.z + 25)
            {
                Destroy(obstacles[i]);
                obstacles.Remove(obstacles[i]);
            }
        }


        int randomSpawnChance1 = Random.Range(0, 400);
        int randomSpawnChance2 = Random.Range(0, 400);
        int randomSpawnChance3 = Random.Range(0, 400);

        int spawnPos = Random.Range(-4, 6);

        if (randomSpawnChance1 < spawnChance1 && Time.timeScale == 1)
        {
            GameObject ob = Instantiate(obstacle1, new Vector3(spawnPos, -2.55f, player.transform.position.z + 175), Quaternion.Euler(0, Random.Range(0, 180), 0));
            obstacles.Add(ob);
        }

        if (randomSpawnChance2 < spawnChance2 && Time.timeScale == 1)
        {
            GameObject ob = Instantiate(obstacle2, new Vector3(spawnPos, -2.55f, player.transform.position.z + 175), Quaternion.Euler(0, Random.Range(0, 180), 0));
            obstacles.Add(ob);
        }

        if (randomSpawnChance3 < spawnChance3 && Time.timeScale == 1)
        {
            GameObject ob = Instantiate(obstacle3, new Vector3(spawnPos, -2.55f, player.transform.position.z + 175), Quaternion.Euler(0, Random.Range(0, 180), 0));
            obstacles.Add(ob);
        }
    }
}
