using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePieceMover : MonoBehaviour
{
    public GameObject rotationCubeForPiece;  // (-90, 180, -180) adaugat in 'picture_frame'
    public GameObject rotationCubeForDoor;  // (0, 280, 0) adaugat in 'door'
    public GameObject controller1; // XR Rig -> Camera Offset -> Left/Right Hand Controller
    public GameObject controller2;
    public GameObject door; // Door_Cube.001
    public GameObject wallOverDoor; // Wall 5
    public AudioSource audioPieceFound; // PlayOnAwayke = false
    public AudioSource audioGameWin; // PlayOnAwayke = false

    private bool found = false;
    private static int countPiecesFound = 0;

    void Start()
    {

    }

    void Update()
    {
        float min_distance = 0.01f;
        if(!found) {
            if((Vector3.Distance(transform.position, controller1.transform.position) < min_distance) ||
               (Vector3.Distance(transform.position, controller2.transform.position) < min_distance)) {
                found = true;

                (GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = false;

                checkToOpenDoor();

                makeSound();
            } 
        }

        if (found){
            transform.localPosition = getPosition();
            transform.rotation = rotationCubeForPiece.transform.rotation;
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

    void checkToOpenDoor() {
        countPiecesFound ++;
        if (countPiecesFound == 3) {
            door.transform.rotation = rotationCubeForDoor.transform.rotation;
            wallOverDoor.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void makeSound() {
        if(countPiecesFound <= 2) {
            audioPieceFound.Play();
        } 
        else {
            audioGameWin.Play();
        }
    }
}
