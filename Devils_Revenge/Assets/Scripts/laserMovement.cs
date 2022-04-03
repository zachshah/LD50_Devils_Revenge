using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMovement : MonoBehaviour
{
    public Transform boundOne;
    public Transform boundTwo;
    public float speed;
    public float timeToMove;
    public float startHeight;
    Vector3 desiredPos;
    // Start is called before the first frame update
    void Start()
    {
        boundOne = GameObject.FindGameObjectWithTag("BoundOne").transform;
        boundTwo = GameObject.FindGameObjectWithTag("BoundTwo").transform;
        desiredPos = new Vector3(Random.Range(boundOne.position.x, boundTwo.position.x), startHeight, Random.Range(boundOne.position.z, boundTwo.position.z));

        InvokeRepeating("pickPosition", timeToMove, timeToMove);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
    }
    void pickPosition()
    {
        desiredPos=new Vector3(Random.Range(boundOne.position.x, boundTwo.position.x),startHeight, Random.Range(boundOne.position.z, boundTwo.position.z));
    }
}
