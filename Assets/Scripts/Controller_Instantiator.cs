using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> Orbes;
    public GameObject instantiatePos;
    public float respawningTimerEnemy = 0f;
    public float respawningTimerOrbe = 0f;
    private float time = 0;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;
        ControllerHealth.velocidadOrbe = 2;
    }

    void Update()
    {
        SpawnEnemies();
        ChangeVelocity();
        SpawnOrbes();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
        ControllerHealth.velocidadOrbe= Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnEnemies()
    {
       respawningTimerEnemy -= Time.deltaTime;

        if (respawningTimerEnemy <= 0)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
           respawningTimerEnemy = UnityEngine.Random.Range(2, 6);
        }
    }

    private void SpawnOrbes() 
    {
        respawningTimerOrbe -= Time.deltaTime;

        if (respawningTimerOrbe <= 0)
        {
            Instantiate(Orbes[UnityEngine.Random.Range(0, Orbes.Count)], instantiatePos.transform);
            respawningTimerOrbe = UnityEngine.Random.Range(5, 10);
        }

    }

}
