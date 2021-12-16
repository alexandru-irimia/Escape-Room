using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class padlock1Code : MonoBehaviour
{
    private static string correctCode = "3471";
    public string code;
    public GameObject inputField;
    public GameObject textDispaly;
    public GameObject form;
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
        }
        else
        {
            textDispaly.GetComponent<Text>().text = "Wrong";
        }

        /*yield return new WaitForSeconds(5);
        form.GetComponent<Canvas>().enabled = false;*/

    }
}