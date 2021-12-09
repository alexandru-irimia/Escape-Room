using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePieceMover : MonoBehaviour
{
    public GameObject cubeForRotation;  // (-90, 180, -180)
    public GameObject controller1; // XR Rig -> Camera Offset -> Left/Right Hand Controller
    public GameObject controller2;

    private bool found = false;
    
    private BoxCollider myCollider;

    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        float min_distance = 0.01f;
        if(!found) {
            if((Vector3.Distance(transform.position, controller1.transform.position) < min_distance) ||
               (Vector3.Distance(transform.position, controller2.transform.position) < min_distance)) {
                found = true;
                (GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = false;
            } 
        }

        if (found){
            transform.localPosition = getPosition();
            transform.rotation = cubeForRotation.transform.rotation;
        }
    }

    Vector3 getPosition(){
        string objectName = name;
        int pieceId = objectName[objectName.Length - 1] - '0';

        switch(pieceId) {
            case 1: return new Vector3(-2.3f, 1f, -42f);
            case 2: return new Vector3(-0.65f, 1f, -42f);
            case 3: return new Vector3(0.5f, 1f, -42f);
            default: return new Vector3(-2.3f, 1f, -42f);
        }
    }
}
