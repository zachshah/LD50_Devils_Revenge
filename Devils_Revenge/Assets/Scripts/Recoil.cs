using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public float rotationSpeed;
    public float returnSpeed;

    public Vector3 RecoilRotation;

    private Vector3 currentRotation;
    private Vector3 Rot;

    public Transform rotationHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, currentRotation, rotationSpeed * Time.deltaTime);
        rotationHandler.localRotation = Quaternion.Euler(Rot);
    }

    public void applyRecoil()
    {
        currentRotation += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
    }
}
