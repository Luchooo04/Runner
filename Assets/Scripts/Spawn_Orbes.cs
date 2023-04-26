using System.Collections.Generic;
using UnityEngine;


public class Spawn_Orbes : MonoBehaviour
{
    public List<GameObject> orbs;
    public GameObject instantiatePos;
    public GameObject spawnerOrb;
    public float respawningTimer;
    private float time = 0;
    public float spawnDelay = 2f;
    public float spawnRageX = 5f;
    public float orbSpawnDelayMin = 5f;
    public float orbSpawnDelayMax = 10f;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);
    }

    void Update()
    {
        SpawnOrbs();
        ChangeVelocity();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        ControllerHealth.velocidadOrbe = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnObject()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(orbs[UnityEngine.Random.Range(0, orbs.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(orbSpawnDelayMin, orbSpawnDelayMax);
        }
    }

    private void SpawnOrbs()
    {
        GameObject spawnedObject = null;
        respawningTimer += Time.deltaTime;

        if (respawningTimer >= spawnDelay)
        {
            float spawnPosX = Random.Range(-spawnRageX, spawnRageX);
            Vector3 spawnPos = new Vector3(spawnPosX, transform.position.y, transform.position.z);
            respawningTimer = 0f;
            spawnedObject = Instantiate(spawnerOrb, spawnPos, Quaternion.identity);
        }
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.left * 5f;
        }
    }
}
