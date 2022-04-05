using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class rockMovement : MonoBehaviour
{
    public Transform boundOne;
    public Transform boundTwo;
    public Animator rockAnim;
    public float timeToMoveMax;
    public float timeToMoveMin;
    float timeToMove;
    public AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        timeToMove = timeToMoveMax;
        Invoke("triggerFall", timeToMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void triggerFall()
    {
        int i = Random.Range(0, 2);
        if (i > 0)
        {
            rockAnim.SetBool("isLeft", true);
        }
        else
        {
            rockAnim.SetBool("isLeft", false);

        }
        StartCoroutine(fallScript());
    }
    IEnumerator fallScript()
    {
        yield return new WaitForSeconds(1f);
        rockAnim.SetBool("isFalling", true);
        yield return new WaitForSeconds(1.5f);
        attackSound.Play();
        yield return new WaitForSeconds(1.7f);
        gameObject.GetComponent<MeshCollider>().enabled = false;
        rockAnim.SetBool("isFalling", false);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<MeshCollider>().enabled = true;
        if (timeToMove > timeToMoveMin)
        {
            timeToMove--;
        }
        Invoke("triggerFall", timeToMove);
    }
}
