using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;
    public Text CurrentTimeTxt, BestTimeTxt;
    int minutesNo, secondsNo;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            return;
        }

        float time = Time.time - startTime;

        minutesNo=( (int)time / 60);
        secondsNo = ((int)time % 60);
        string minutes= minutesNo.ToString();
        string seconds = secondsNo.ToString("f2");
       
        timerText.text = minutes + ":" + seconds;
    }

    public void Finish() {
        finished = true;
        if (minutesNo==0 ||  PlayerPrefs.GetInt("BestMinKey")> minutesNo)
        {
            PlayerPrefs.SetInt("BestMinKey", minutesNo);
            PlayerPrefs.SetInt("BestSecKey", secondsNo);
        }
       

        timerText.color = Color.yellow;
        CurrentTimeTxt.text = timerText.text;

        BestTimeTxt.text = PlayerPrefs.GetInt("BestMinKey").ToString() +":"+ PlayerPrefs.GetInt("BestSecKey").ToString();

    }
}
