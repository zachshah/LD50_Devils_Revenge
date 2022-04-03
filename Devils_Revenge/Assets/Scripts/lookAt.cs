using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public bool setRotationToInstead;
    public Transform objectToLookAt;
    public bool xyOnly;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!setRotationToInstead) {
            if (xyOnly) {
                transform.LookAt(new Vector3(objectToLookAt.position.x, transform.position.y, objectToLookAt.position.z));
                    }
            else
            {
                transform.LookAt(objectToLookAt.position);
            }
        }
        else
        {
            transform.rotation = objectToLookAt.rotation;
        }
       
        
       

    }
}
