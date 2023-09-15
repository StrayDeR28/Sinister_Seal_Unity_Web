using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToContinue : MonoBehaviour
{
    private Animator animator;
    private bool flagForButton=false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PressSpace());
    }
    public IEnumerator PressSpace()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true || flagForButton)
            {
                animator.SetTrigger("Hide");
                yield return new WaitForSeconds(0.5f);
                gameObject.SetActive(false); 
                StopCoroutine(PressSpace());
            }
            yield return null;
        }
       
    }
    public void StartEnum()
    {
        flagForButton = true;
        StartCoroutine(PressSpace());
    }
}
