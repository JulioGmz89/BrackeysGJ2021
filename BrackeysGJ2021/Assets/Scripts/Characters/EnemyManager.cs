using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elements;

public class EnemyManager : MonoBehaviour
{
    public Transform[] playerTransforms;
    private GameObject[] players;

    public float moveSpeed = 10f;
    public Element myElement;
    
    protected virtual void GetPlayerTransforms()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            playerTransforms = playerTransforms.Append(player.GetComponent<Transform>()).ToArray();
        }
    }
    protected virtual void EnemyMovement()
    {
        Debug.Log(playerTransforms[0].position);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, GetClosestPlayer(playerTransforms).position, moveSpeed*Time.deltaTime);
    }
    protected virtual Transform GetClosestPlayer(Transform[] players)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in players)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
    
}
