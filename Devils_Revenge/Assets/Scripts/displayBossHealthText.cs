using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayBossHealthText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Mathf.Round(GameObject.FindGameObjectWithTag("BossData").GetComponent<saveDataBoss>().bossHealth*100f)*.01f + "%";
    }
}
