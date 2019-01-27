using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string sceneToChangeTo;
    public void ChangeScene()
    {
        if (SceneManager.GetSceneByName(sceneToChangeTo) != null)
        {
            SceneManager.LoadScene(sceneToChangeTo);
        }
;    }
}
