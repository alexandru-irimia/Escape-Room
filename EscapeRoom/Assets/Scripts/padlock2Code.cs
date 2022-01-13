
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class padlock2Code : MonoBehaviour
{
    private static string correctCode = "36";
    public string code;
    public GameObject inputField;
    public GameObject textDispaly;
    public GameObject form;
    public GameObject LogicPuzzle; // trebuie dezactivat din Unity XRGrabInteractable mai intai
    public GameObject picturePiece2; // trebuie dezactivat din Unity XRGrabInteractable mai intai
    public GameObject padlock1;
    public AudioSource audio;
    [SerializeField] public Animator unlockAnim;
    [SerializeField] public Animator shelfAnim;

    public void Start()
    {
        form.GetComponent<Canvas>().enabled = false;
    }

    public void displayForm()
    {
        form.GetComponent<Canvas>().enabled = true;
    }

    public void displayCode()
    {
        code = inputField.GetComponent<Text>().text;
        if (code == correctCode)
        {
            textDispaly.GetComponent<Text>().text = "Correct";
            unlockAnim.SetBool("unlock", true);
            shelfAnim.SetBool("OpenBookShelf2", true);
            form.GetComponent<Canvas>().enabled = false;

            // padlock1.transform.position += new Vector3(0.9f, 0f, 0f); // se muta instant si nush cum sa il fac sa se mute odata cu animatia
            padlock1.SetActive(false);

            (picturePiece2.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
            (LogicPuzzle.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
            audio.Play();
        }
        else
        {
            textDispaly.GetComponent<Text>().text = "Wrong";
        }

        /*yield return new WaitForSeconds(5);
        form.GetComponent<Canvas>().enabled = false;*/

    }


}