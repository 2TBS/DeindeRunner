using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MM_Helpers : MonoBehaviour {

    public Animator animator;
    public bool optionsBool = false;
    int x = 0;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
    }

	public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleOptions() {
        if(optionsBool){
            animator.SetFloat("SpeedMultiplier", -1.0f);
        }
        else{
            animator.SetFloat("SpeedMultiplier", 1.0f);
        }
        optionsBool = !optionsBool;
        animator.SetBool("Options", optionsBool);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(x);
    }
    public void Stage() {
       x = 1;
        SceneManager.LoadScene(x);
    }
}
