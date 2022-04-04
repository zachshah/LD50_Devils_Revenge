using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class swapLevels : MonoBehaviour
{
    public NavMeshSurface surface;
    public Transform sceneOne;
    public Transform sceneTwo;
    public Transform sceneThree;
    int whichScene;
    int swapTime;
    public int maxSwapTime;
    public int minSwapTime;
    public Vector3 hiddenPos;
    public Vector3 shownPos;
    public float swapSpeed;
    public AudioSource levelSound;


    // Start is called before the first frame update
    void Start()
    {
        swapTime = maxSwapTime;
        Invoke("triggerSwap", swapTime);
        InvokeRepeating("generateMesh", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (whichScene == 0)
        {
            
            sceneOne.localPosition = Vector3.Lerp(sceneOne.localPosition,shownPos,swapSpeed*Time.deltaTime);
            sceneTwo.localPosition = Vector3.Lerp(sceneTwo.localPosition, hiddenPos, swapSpeed*Time.deltaTime);
            sceneThree.localPosition = Vector3.Lerp(sceneThree.localPosition, hiddenPos, swapSpeed*Time.deltaTime);
        }
        else if(whichScene == 1)
        {
            sceneOne.localPosition = Vector3.Lerp(sceneOne.localPosition, hiddenPos, swapSpeed*Time.deltaTime);
            sceneTwo.localPosition = Vector3.Lerp(sceneTwo.localPosition, shownPos, swapSpeed*Time.deltaTime);
            sceneThree.localPosition = Vector3.Lerp(sceneThree.localPosition, hiddenPos, swapSpeed*Time.deltaTime);
        }
        else if(whichScene == 2)
        {
            sceneOne.localPosition = Vector3.Lerp(sceneOne.localPosition, hiddenPos, swapSpeed*Time.deltaTime);
            sceneTwo.localPosition = Vector3.Lerp(sceneTwo.localPosition, hiddenPos, swapSpeed*Time.deltaTime);
            sceneThree.localPosition = Vector3.Lerp(sceneThree.localPosition, shownPos, swapSpeed*Time.deltaTime);
        }
    }
    void triggerSwap()
    {
        if (swapTime > minSwapTime)
        {
            swapTime--;
        }
        Debug.Log(whichScene);
        levelSound.Play();
        whichScene = Random.Range(0, 3);
        
        Invoke("triggerSwap", swapTime);
    }
   
    void generateMesh()
    {
        surface.BuildNavMesh();
    }
}
