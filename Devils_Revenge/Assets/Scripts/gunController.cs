using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public float timeBetweenShots;
    bool canShoot=true;

    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;
    public float swayMultiplier;
    public float smooth;
    public Transform swayHandler;
    public Recoil recoil;
    public AudioSource shootSound;
    public AudioSource deathSound;
    public Camera fpsCam;
    public LayerMask hittableMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) )
        {
            if (canShoot)
            {
                canShoot = false;
                Fire();
                Invoke("resetShot", timeBetweenShots);
            }
        }
        float mouseX = Input.GetAxis("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * swayMultiplier;

        Quaternion rotX = Quaternion.AngleAxis(mouseY, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(-mouseX, Vector3.up);

        Quaternion targetRotation = rotX * rotY;
        swayHandler.localRotation = Quaternion.Slerp(swayHandler.localRotation, targetRotation, smooth * Time.deltaTime);
    }
    void Fire()
    {
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, hittableMask))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                if (hit.transform.gameObject.GetComponent<enemyHealth>().health > 1)
                {
                    hit.transform.gameObject.GetComponent<enemyHealth>().takeDamage();
                }
                else
                {
                    deathSound.Play();
                    GameObject.FindGameObjectWithTag("Boss").GetComponent<dialogueController>().dialogueDiceDeath();
                    hit.transform.gameObject.GetComponent<enemyHealth>().takeDamage();
                }
            }
            if (hit.transform.gameObject.tag == "Boss")
            {
                hit.transform.gameObject.GetComponent<dialogueController>().dialogueDiceHurt();
            }

            }
        shootSound.Play();
        recoil.applyRecoil();
        smokeEffect.Play();
        fireEffect.Play();
    }
    void resetShot()
    {
        canShoot = true;
    }
    
}
