using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class padlock3Code : MonoBehaviour
{
    private static string correctCode = "042";
    public string code;
    public GameObject inputField;
    public GameObject textDispaly;
    public GameObject form;
    public GameObject picturePiece3;  
    public GameObject padlock3; 
    [SerializeField] public Animator unlockAnim;
    [SerializeField] public Animator shelfAnim;
    public AudioSource auido;

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
            shelfAnim.SetBool("OpenDrawer", true);
            form.GetComponent<Canvas>().enabled = false;

            padlock3.SetActive(false);
            (picturePiece3.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
            auido.Play();
        }
        else
        {
            textDispaly.GetComponent<Text>().text = "Wrong";
        }

        /*yield return new WaitForSeconds(5);
        form.GetComponent<Canvas>().enabled = false;*/

    }
}