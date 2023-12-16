using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterMove : MonoBehaviour
{
    public bool ExitActivate = false;
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        Anim.SetBool("IsMove", true);
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player" & ExitActivate)
        {
            StartCoroutine(StartEnd());
            
            

        }
    }

    IEnumerator StartEnd()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
