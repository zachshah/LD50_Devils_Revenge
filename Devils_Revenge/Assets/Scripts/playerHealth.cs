using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float playerHealthMax;
    public float playerHealthCurrent;
    public Image healthOne;
    public Image healthTwo;
    public Image healthThree;
    public Image healthFour;
    public Image healthFive;
    public Image healthSix;
    public Image healthSeven;
    public Image healthEight;

    public GameObject recoilCam;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthCurrent = playerHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthCurrent >= 8)
        {
            healthOne.fillAmount = 1;
            healthTwo.fillAmount = 1;
            healthThree.fillAmount = 1;
            healthFour.fillAmount = 1;
            healthFive.fillAmount = 1;
            healthSix.fillAmount = 1;
            healthSeven.fillAmount = 1;
            healthEight.fillAmount = 1;
        }else if (playerHealthCurrent > 7)
        {
            healthOne.fillAmount = playerHealthCurrent - 7;
            healthTwo.fillAmount = 1;
            healthThree.fillAmount = 1;
            healthFour.fillAmount = 1;
            healthFive.fillAmount = 1;
            healthSix.fillAmount = 1;
            healthSeven.fillAmount = 1;
            healthEight.fillAmount = 1;
        }
        else if (playerHealthCurrent > 6)
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = playerHealthCurrent - 6;
            healthThree.fillAmount = 1;
            healthFour.fillAmount = 1;
            healthFive.fillAmount = 1;
            healthSix.fillAmount = 1;
            healthSeven.fillAmount = 1;
            healthEight.fillAmount = 1;
        }
        else if (playerHealthCurrent > 5)
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = 0;
            healthThree.fillAmount = playerHealthCurrent - 5;
            healthFour.fillAmount = 1;
            healthFive.fillAmount = 1;
            healthSix.fillAmount = 1;
            healthSeven.fillAmount = 1;
            healthEight.fillAmount = 1;
        }
        else if (playerHealthCurrent > 4)
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = 0;
            healthThree.fillAmount = 0;
            healthFour.fillAmount = playerHealthCurrent - 4;
            healthFive.fillAmount = 1;
            healthSix.fillAmount = 1;
            healthSeven.fillAmount = 1;
            healthEight.fillAmount = 1;
        }
        else if (playerHealthCurrent > 3)
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = 0;
            healthThree.fillAmount = 0;
            healthFour.fillAmount = 0;
            healthFive.fillAmount = playerHealthCurrent - 3;
            healthSix.fillAmount = 1;
            healthSeven.fillAmount = 1;
            healthEight.fillAmount = 1;
        }
        else if (playerHealthCurrent > 2)
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = 0;
            healthThree.fillAmount = 0;
            healthFour.fillAmount = 0;
            healthFive.fillAmount = 0;
            healthSix.fillAmount = playerHealthCurrent - 2;
            healthSeven.fillAmount = 1;
            healthEight.fillAmount = 1;
        }
        else if (playerHealthCurrent > 1)
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = 0;
            healthThree.fillAmount = 0;
            healthFour.fillAmount = 0;
            healthFive.fillAmount = 0;
            healthSix.fillAmount = 0;
            healthSeven.fillAmount = playerHealthCurrent - 1;
            healthEight.fillAmount = 1;
        }
        else if (playerHealthCurrent > 0)
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = 0;
            healthThree.fillAmount = 0;
            healthFour.fillAmount = 0;
            healthFive.fillAmount = 0;
            healthSix.fillAmount = 0;
            healthSeven.fillAmount = 0;
            healthEight.fillAmount = playerHealthCurrent;
        }
        else
        {
            healthOne.fillAmount = 0;
            healthTwo.fillAmount = 0;
            healthThree.fillAmount = 0;
            healthFour.fillAmount = 0;
            healthFive.fillAmount = 0;
            healthSix.fillAmount = 0;
            healthSeven.fillAmount = 0;
            healthEight.fillAmount = 0;

        }
    }
    public void takeDamage(float damageAmount)
    {
        recoilCam.GetComponent<Recoil>().applyRecoil();
        if (playerHealthCurrent > damageAmount)
        {
            playerHealthCurrent -= damageAmount;
        }
        else
        {
            playerHealthCurrent -= damageAmount;
            death();
        }
    }
    void death()
    {
        SceneManager.LoadScene(2);

    }
}
