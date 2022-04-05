using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveDataBoss : MonoBehaviour
{
    public float bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss") != null) {
            bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<dialogueController>().bossHealth;
                }
    }
}
