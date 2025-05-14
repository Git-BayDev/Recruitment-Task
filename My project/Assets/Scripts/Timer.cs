using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float currTime = 0;
    public TextMeshProUGUI timerText;
    public Camera cam;


    private void Start()
    {
        cam.enabled = false;
        timerText.enabled = false;
    }

    private void Update()
    {
        if(cam.enabled == true)
        {
            timerText.enabled = true;
            currTime += Time.deltaTime;

            int min = (int)(currTime / 60f);
            int sec = (int)(currTime % 60f);
            int msec = (int)((currTime - Mathf.FloorToInt(currTime)) * 100);

            string time = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);

            timerText.text = time;
        }

    }

}
