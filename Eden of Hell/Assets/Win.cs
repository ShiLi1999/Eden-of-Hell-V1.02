using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

    public void Link(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Debug.Log("buttonISPressed");
    }
}
