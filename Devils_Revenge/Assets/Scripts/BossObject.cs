using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObject : MonoBehaviour
{
    public float damage;
    public AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dealDamage();
        }
    }
    void dealDamage()
    {
        attackSound.Play();
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>().takeDamage(damage);
        Debug.Log("That did: "+damage+" hp");
    }
}
