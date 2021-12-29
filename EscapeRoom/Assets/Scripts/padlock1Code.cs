using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class padlock1Code : MonoBehaviour
{
    private static string correctCode = "3471";
    public string code;
    public GameObject inputField;
    public GameObject textDispaly;
    public GameObject form;
    public GameObject clipboard; // trebuie dezactivat din Unity XRGrabInteractable mai intai
    public GameObject picturePiece1; // trebuie dezactivat din Unity XRGrabInteractable mai intai
    public GameObject padlock1; 
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
            shelfAnim.SetBool("OpenBookShelf", true);
            form.GetComponent<Canvas>().enabled = false;
     
            // padlock1.transform.position += new Vector3(0.9f, 0f, 0f); // se muta instant si nush cum sa il fac sa se mute odata cu animatia
            padlock1.SetActive(false);

            (picturePiece1.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
            (clipboard.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
        }
        else
        {
            textDispaly.GetComponent<Text>().text = "Wrong";
        }

        /*yield return new WaitForSeconds(5);
        form.GetComponent<Canvas>().enabled = false;*/

    }

    
}