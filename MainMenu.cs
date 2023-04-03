using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject modes;
    public bool modesVisible = false;

    public GameObject playButton;
    public GameObject threeButtons;
    public GameObject twoButtons;

    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModesButtonVisibility()
    {
        if (modesVisible)
        {
            ReverseButtonAnimation();
            List<Animation> modesButtonsRef = new List<Animation>();
            for (int i = 0; i < 3; i++)
            {
                modesButtonsRef.Add(modes.transform.GetChild(i).GetComponent<Animation>());
                StartCoroutine(SetActiveAfterAnim(modesButtonsRef[i], modes, false));
                modes.transform.GetChild(i).GetComponent<Button>().enabled = false;
            }
            modesVisible = false;
        }

        else
        {
            ResetAnimation();
            modes.SetActive(true);
            modesVisible = true;
            List<Animation> modesButtonsRef = new List<Animation>();
            for (int i = 0; i < 3; i++)
            {
                modesButtonsRef.Add(modes.transform.GetChild(i).GetComponent<Animation>());
                modesButtonsRef[i].Play();
               modes.transform.GetChild(i).GetComponent<Button>().enabled = true;
            }
        }

    }

    public void PlayButtonAnimation()
    {
        List<Animation> twoButtonsRef = new List<Animation>();
        for (int i = 0; i < 2; i++)
        {
            twoButtonsRef.Add(twoButtons.transform.GetChild(i).GetComponent<Animation>());
            twoButtons.transform.GetChild(i).GetComponent<Button>().enabled = false;
            twoButtonsRef[i].Play();
        }

        List<Animation> threeButtonsRef = new List<Animation>();
        for (int i = 0; i < 3; i++)
        {
            threeButtonsRef.Add(threeButtons.transform.GetChild(i).GetComponent<Animation>());
            threeButtons.transform.GetChild(i).GetComponent<Button>().enabled = false;
            threeButtonsRef[i].Play();
        }
        Animation playAnim = playButton.GetComponent<Animation>();
        playButton.GetComponent<Button>().enabled = false;
        playAnim.Play();

        backButton.SetActive(true);
        Animation backAnim = backButton.GetComponent<Animation>();
        backAnim.Play();

    }

    public void ReverseButtonAnimation()
    {
        List<Animation> twoButtonsRef = new List<Animation>();
        for (int i = 0; i < 2; i++)
        {
            twoButtonsRef.Add(twoButtons.transform.GetChild(i).GetComponent<Animation>());
            twoButtons.transform.GetChild(i).GetComponent<Button>().enabled = true;
            twoButtonsRef[i]["TwoButtons"].normalizedTime = 1;
            twoButtonsRef[i]["TwoButtons"].speed = -1.0f;
            twoButtonsRef[i].Play();
        }

        List<Animation> threeButtonsRef = new List<Animation>();
        for (int i = 0; i < 3; i++)
        {
            threeButtonsRef.Add(threeButtons.transform.GetChild(i).GetComponent<Animation>());
            threeButtons.transform.GetChild(i).GetComponent<Button>().enabled = true;
            threeButtonsRef[i]["ThreeButtons"].normalizedTime = 1;
            threeButtonsRef[i]["ThreeButtons"].speed = -1.0f;
            threeButtonsRef[i].Play();
        }
        Animation playAnim = playButton.GetComponent<Animation>();
        playButton.GetComponent<Button>().enabled = true;
        playAnim["PlayButtonAnimation"].normalizedTime = 1;
        playAnim["PlayButtonAnimation"].speed = -1.0f;
        playAnim.Play();

        Animation backAnim = backButton.GetComponent<Animation>();
        backAnim["BackButton"].normalizedTime = 1;
        backAnim["BackButton"].speed = -1.0f;
        backAnim.Play();
        StartCoroutine(SetActiveAfterAnim(backAnim, backButton, false));

        List<Animation> modesButtonsRef = new List<Animation>();
        for (int i = 0; i < 3; i++)
        {
            modesButtonsRef.Add(modes.transform.GetChild(i).GetComponent<Animation>());
            modesButtonsRef[i]["BackButton"].normalizedTime = 1;
            modesButtonsRef[i]["BackButton"].speed = -1.0f;
            modesButtonsRef[i].Play();
        }
    }

    public void ResetAnimation()
    {
        List<Animation> twoButtonsRef = new List<Animation>();
        for (int i = 0; i < 2; i++)
        {
            twoButtonsRef.Add(twoButtons.transform.GetChild(i).GetComponent<Animation>());
            twoButtonsRef[i]["TwoButtons"].normalizedTime = 0;
            twoButtonsRef[i]["TwoButtons"].speed = 1.0f;
        }

        List<Animation> threeButtonsRef = new List<Animation>();
        for (int i = 0; i < 3; i++)
        {
            threeButtonsRef.Add(threeButtons.transform.GetChild(i).GetComponent<Animation>());
            threeButtonsRef[i]["ThreeButtons"].normalizedTime = 0;
            threeButtonsRef[i]["ThreeButtons"].speed = 1.0f;
        }
        Animation playAnim = playButton.GetComponent<Animation>();
        playAnim["PlayButtonAnimation"].normalizedTime = 0;
        playAnim["PlayButtonAnimation"].speed = 1.0f;

        Animation backAnim = backButton.GetComponent<Animation>();
        backAnim["BackButton"].normalizedTime = 0;
        backAnim["BackButton"].speed = 1.0f;

        List<Animation> modesButtonsRef = new List<Animation>();
        for (int i = 0; i < 3; i++)
        {
            modesButtonsRef.Add(modes.transform.GetChild(i).GetComponent<Animation>());
            modesButtonsRef[i]["BackButton"].normalizedTime = 0;
            modesButtonsRef[i]["BackButton"].speed = 1.0f;
        }
    }

   public IEnumerator SetActiveAfterAnim(Animation anim, GameObject animObject, bool yes)
    {
        if(anim.isPlaying)
        {
            yield return new WaitForSeconds(anim.clip.length);
            animObject.SetActive(yes);
        }
        yield return null;
    }
}
