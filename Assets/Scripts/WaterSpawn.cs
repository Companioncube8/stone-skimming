using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour {

    public GameObject[] Water;
    public GameObject WaterPrefub;
    public GameObject WaterWithIslandPrefub1;
    public GameObject WaterWithIslandPrefub2;
    public GameObject WaterWithIslandPrefub3;

    [SerializeField] private GameObject player;

    private float spawnZ = 0.0f;
    private float length = 20.0f;
    private int counter = 7;
    private Vector3 pos;
    private int index;

	private void Awake () {

        Water = new GameObject[counter];
        for (int i = 0; i < counter; i++)
        {
            Spawn(i);
        }
        index = 0;
	}
	
	private void Update () {
		if(player.transform.position.z > ((spawnZ + 2) - (counter - 1) * length))
        {
            Delete(index);
            Spawn(index);
            if (index == counter - 1)
            {
                index = 0;
            } else
            {
                index++;
            }
        }
	}

    private void Spawn(int i)
    {
        int water = Random.Range(0, 10);
        pos.z = spawnZ;
        if (water == 0)
            Water[i] = Instantiate(WaterWithIslandPrefub1, pos, transform.rotation);
        if (water == 1)
            Water[i] = Instantiate(WaterWithIslandPrefub2, pos, transform.rotation);
        if (water == 2)
            Water[i] = Instantiate(WaterWithIslandPrefub3, pos, transform.rotation);
        if (water > 2)
            Water[i] = Instantiate(WaterPrefub, pos, transform.rotation);
        spawnZ += length;
    }

    private void Delete(int i)
    {
        Destroy(Water[i]);
    }
}
