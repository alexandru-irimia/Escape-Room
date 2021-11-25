using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    public float speed;
    Animator animator;
    SkinnedMeshRenderer mesh;

    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "grip";
    private string animatorTriggerParam = "trigger";
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animateHand();
    }

    public void SetGrip(float value)
    {
        gripTarget = value;
    }

    public void SetTrigger(float value){
        triggerTarget = value;
    }


    void animateHand()
    {
        if(gripCurrent != gripTarget)
        {
            gripCurrent =  Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }

        if(triggerCurrent != triggerTarget)
        {
            triggerCurrent =  Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }

    public void toggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
