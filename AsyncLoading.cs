using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoading : MonoBehaviour
{

    public Text text;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(LoadButton);
    }

    void LoadButton()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("PVP");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
      //  Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
               // text.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
               // if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
