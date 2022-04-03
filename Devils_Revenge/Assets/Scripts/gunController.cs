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
        recoil.applyRecoil();
        smokeEffect.Play();
        fireEffect.Play();
    }
    void resetShot()
    {
        canShoot = true;
    }
}
