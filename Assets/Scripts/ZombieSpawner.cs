using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int MaxZombieSpawn=5;
    public float spawnInterval=5f;
    float nextSpawnTime=0f;
    public GameObject ZombiePrefab;
    int ZombiesSpawned=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>=nextSpawnTime && ZombiesSpawned<MaxZombieSpawn){
            Instantiate(ZombiePrefab, transform.position, Quaternion.identity);
            nextSpawnTime=Time.time+spawnInterval;
            ZombiesSpawned++;
        }
    }
}
