using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject[] EnemySpawns;
    private int[] squad1 = { 0, 1 };
    private int[] squad2 = { 2, 3 };
    private int[] squad3 = { 4, 4 };
    void Start()
    {
        StartCoroutine(SpawnWave(2, squad1, 0));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnWave(int waveSize, int[] enemySquad, int spawnIndex)
    {
        for (int i = 1; i < waveSize+1; i++)
        {
            Debug.Log("Spawning wave: " + i);
            for (int t = 0; t < enemySquad.Length; t++)
            {
                Instantiate(Enemies[enemySquad[t]],EnemySpawns[spawnIndex].transform.position, Quaternion.Euler(90,0,0));
                yield return new WaitForSeconds(.5f);
            }
            yield return new WaitForSeconds(.5f);
        }
    }
}
