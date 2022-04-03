using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyLimb : MonoBehaviour
{
    public Transform targetLimb;
    public ConfigurableJoint m_ConfigurableJoint;

    Quaternion targetInitialRotation;
    // Start is called before the first frame update
    void Start()
    {
        this.m_ConfigurableJoint = this.GetComponent<ConfigurableJoint>();
        this.targetInitialRotation = this.targetLimb.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.m_ConfigurableJoint.targetRotation = copyRotation();
    }

    Quaternion copyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
}
