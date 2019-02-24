﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public Terrain terrain;
    public GameObject road;
    public GameObject wall;
    public GameObject fence;

    GameObject player;

    List<Terrain> terrains;
    List<GameObject> roads;
    List<GameObject> walls;

    float defaultTerrainX = -250;
    float defaultTerrainY = -3;

    Terrain terrain1;
    Terrain terrain2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        terrains = new List<Terrain>();
        roads = new List<GameObject>();
        walls = new List<GameObject>();

        Terrain terrain1 = Instantiate(terrain, new Vector3(defaultTerrainX, defaultTerrainY, -10), Quaternion.identity, null);
        terrains.Add(terrain1);
        Terrain terrain2 = Instantiate(terrain, new Vector3(defaultTerrainX, defaultTerrainY, 490), Quaternion.identity, null);
        terrains.Add(terrain2);

        GameObject road1 = Instantiate(road, new Vector3(0, -2.6f, 240), Quaternion.identity, null);
        roads.Add(road1);
        GameObject road2 = Instantiate(road, new Vector3(0, -2.6f, 740), Quaternion.identity, null);
        roads.Add(road2);

        int spawnChance = 2;


        for (int i = 0; i < 192; i++)
        {
            float random = Random.Range(0, 100);
            if (spawnChance < random)
            {
                GameObject rightWall = Instantiate(wall, new Vector3(7, -2.8f, i * 2.6f - 8.75f), Quaternion.identity, null);
                rightWall.transform.rotation *= Quaternion.Euler(0, 90f, 0);
                walls.Add(rightWall);
            }
            else
            {
                GameObject rightFence = Instantiate(fence, new Vector3(7, -2.8f, i * 2.6f - 8.75f), Quaternion.identity, null);
                rightFence.transform.rotation *= Quaternion.Euler(0, 90f, 0);
                walls.Add(rightFence);
            }

            random = Random.Range(0, 100);
            if (spawnChance < random)
            {
                GameObject leftWall = Instantiate(wall, new Vector3(-7, -2.8f, i * 2.6f - 8.75f), Quaternion.identity, null);
                leftWall.transform.rotation *= Quaternion.Euler(0, -90, 0);
                walls.Add(leftWall);
            }
            else
            {
                GameObject leftFence = Instantiate(fence, new Vector3(-7, -2.8f, i * 2.6f - 8.75f), Quaternion.identity, null);
                leftFence.transform.rotation *= Quaternion.Euler(0, -90f, 0);
                walls.Add(leftFence);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < walls.Count; i++)
        {
            if (player.transform.position.z > walls[i].transform.position.z + 25)
            {
                walls[i].transform.Translate(0, 0, terrain.terrainData.size.z, Space.World);
            }
        }

        if (player.transform.position.z > (terrains[0].transform.position.z + terrain.terrainData.size.z))
        {
            terrains[0].transform.Translate(0, 0, terrains[1].terrainData.size.z * 2);

            Terrain temp = terrains[0];
            terrains.Remove(terrains[0]);
            terrains.Add(temp);

            roads[0].transform.Translate(0, 0, terrains[1].terrainData.size.z * 2);

            GameObject tempRoad = roads[0];
            roads.Remove(roads[0]);
            roads.Add(tempRoad);
        }
    }
}
