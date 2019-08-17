using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingScript : MonoBehaviour {

    public Text loadingText;
    public Slider progressSlider;
    public Text percentText;
    public Text doingStuffText;
    float delay;
    public Button okay;
    public Button wholeScreenButton;
    Camera cam;
    public Color bg;
    List<string> list = new List<string>();
    List<string> suspicious = new List<string>();
    bool suspiciousInstall;

	void Start()
    {
        list.Add("Downloading content...");
        list.Add("Extracting files...");
        list.Add("Installing content...");
        list.Add("Checking installation...");
        list.Add("Updating software...");
        list.Add("Downloading software...");
        list.Add("Installing software...");
        list.Add("Deleting temporary files...");
        suspicious.Add("Downloading viruses...");
        suspicious.Add("Installing viruses...");
        suspicious.Add("Deleting system files...");
        suspicious.Add("Downloading useless content...");
        suspicious.Add("Deleting useful content...");
        suspicious.Add("Deleting antivirus software...");
        cam = Camera.main;
        okay.transform.localScale = Vector2.zero;
        loadingText.transform.localScale = Vector2.zero;
        progressSlider.transform.localScale = Vector2.zero;
        percentText.transform.localScale = Vector2.zero;
        doingStuffText.transform.localScale = Vector2.zero;
        wholeScreenButton.transform.localScale = Vector2.zero;
        StartCoroutine("UpdateText");
    }

    void Update()
    {
        if(progressSlider.value == progressSlider.maxValue)
        {
            StopAllCoroutines();
            loadingText.text = "Finished";
            doingStuffText.text = "Loading completed";
            okay.transform.localScale = Vector2.one;
        }
    }

    IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(0.5f);
        cam.backgroundColor = bg;
        yield return new WaitForSeconds(0.5f);
        loadingText.transform.localScale = Vector2.one;
        wholeScreenButton.transform.localScale = Vector2.one;
        loadingText.text = "Loading";
        yield return new WaitForSeconds(0.5f);
        loadingText.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        loadingText.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loadingText.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        loadingText.transform.localScale = Vector2.zero;
        wholeScreenButton.transform.localScale = Vector2.zero;
        cam.backgroundColor = Color.black;
        yield return new WaitForSeconds(1f);
        StartCoroutine("Load");
        StartCoroutine("Load2");
        while (true)
        {
            loadingText.text = "Loading";
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "Loading.";
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "Loading..";
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "Loading...";
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Load()
    {
        cam.backgroundColor = bg;
        yield return new WaitForSeconds(0.5f);
        loadingText.transform.localScale = Vector2.one;
        progressSlider.transform.localScale = Vector2.one;
        percentText.transform.localScale = Vector2.one;
        yield return new WaitForSeconds(1f);
        while (true)
        {
            delay = Random.Range(0, 1f);
            progressSlider.value += 1;
            percentText.text = (progressSlider.value.ToString() + " %");
            yield return new WaitForSeconds(delay);
        }
    }

    public void Okay()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator Load2()
    {
        yield return new WaitForSeconds(0.5f);
        doingStuffText.transform.localScale = Vector2.one;
        while(true)
        {
            if (suspiciousInstall)
            {
                doingStuffText.text = suspicious[Random.Range(0, suspicious.Count)];
            }
            else
            {
                doingStuffText.text = list[Random.Range(0, list.Count)];
            }
            yield return new WaitForSeconds(Random.Range(1f, 10f));
        }
    }

    public void ToggleSuspiciousInstall()
    {
        suspiciousInstall = true;
    }
}
