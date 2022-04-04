using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueController : MonoBehaviour
{
    public GameObject dialogueBox;
    public Animator dialogueAnim;
    bool displayingNow;
    public Image healthBarScalable;
    public float bossHealth;
    public float bossHealthMax;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = bossHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dialogueDiceDeath()
    {
        if (Random.Range(0, 11) > 9)
        {
            if (!displayingNow)
            {
                displayingNow = true;
                StartCoroutine(dialogueDeathTimer());
            }

           }
    }
    public void dialogueDiceHurt()
    {
        bossHealth *= .97f;
        healthBarScalable.fillAmount =  bossHealth/bossHealthMax;
        if (Random.Range(0, 20) > 17)
        {
            if (!displayingNow)
            {
                displayingNow = true;
                StartCoroutine(dialogueHurtTimer());
            }

        }
    }
    IEnumerator dialogueDeathTimer()
    {
        int whichChild = Random.Range(0, 11);
        dialogueBox.transform.GetChild(4).GetChild(whichChild).gameObject.SetActive(true);
        dialogueAnim.SetBool("isDisplaying", true);
        yield return new WaitForSeconds(6);
        dialogueAnim.SetBool("isDisplaying", false);
        dialogueBox.transform.GetChild(4).GetChild(whichChild).gameObject.SetActive(false);
        displayingNow = false;

    }
    IEnumerator dialogueHurtTimer()
    {
        int whichChild = Random.Range(0, 11);
        dialogueBox.transform.GetChild(5).GetChild(whichChild).gameObject.SetActive(true);
        dialogueAnim.SetBool("isDisplaying", true);
        yield return new WaitForSeconds(6);
        dialogueAnim.SetBool("isDisplaying", false);
        dialogueBox.transform.GetChild(5).GetChild(whichChild).gameObject.SetActive(false);
        displayingNow = false;

    }
}
