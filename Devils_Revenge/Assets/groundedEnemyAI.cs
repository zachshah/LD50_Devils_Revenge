using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class groundedEnemyAI : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent enemy;
    public NavMeshSurface surface;
    public LayerMask groundLayer;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generateMesh", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RaycastHit hit;
        if(Physics.Raycast(player.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            enemy.SetDestination(hit.point);
        }
       
               
       
    }
    void generateMesh()
    {
        surface.BuildNavMesh();
    }
}
