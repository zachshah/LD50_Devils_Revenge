using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class enemyAttackLogic : MonoBehaviour
{
    public GameObject player;
    public float attackDistance;
    bool attacking = false;
    public float hitSpeed;
    public float repeatedHitSpeedModifier;
    public float damage;
    public Animator anim;
    public AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            anim.SetBool("isCharging", true);
            if (!attacking)
            {
                
                attacking = true;
                InvokeRepeating("dealDamage", hitSpeed, hitSpeed+ repeatedHitSpeedModifier);
            }
        }
        else
        {
            anim.SetBool("isCharging", false);
            attacking = false;
            CancelInvoke("dealDamage");
        }
    }
    void dealDamage()
    {
        attackSound.Play();
        player.GetComponent<playerHealth>().takeDamage(damage);
        Debug.Log("hit for: " + damage + " hp");
    }
}
