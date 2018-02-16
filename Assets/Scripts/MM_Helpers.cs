using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MM_Helpers : MonoBehaviour {

    public GameObject optionsPanel;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        optionsPanel.SetActive(false);
    }

	public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleOptions() {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
