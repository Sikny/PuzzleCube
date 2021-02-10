using TMPro;
using UnityEngine;


public class Chrono : MonoBehaviour
{
    [SerializeField] private float timePerLevel; // temps du compte à rebours en secondes
    [SerializeField] private TextMeshProUGUI  countdown; 
    [SerializeField] private TextMeshProUGUI  chrono;
    private float _currentTimePerLevel;
    private float _currentChrono;
    private float currentTime;

    private bool isStop;

    private void Start()
    {
        isStop = false;
        _currentTimePerLevel = timePerLevel;
        currentTime = _currentTimePerLevel;
    }

    public void ResetChrono()
    {
        _currentChrono = 0;
    }

    public void ResetCountdown()
    {
       currentTime = timePerLevel;
    }

    public bool Stop()
    {
        if(currentTime <= 0)
        {
            isStop = true;
        }
        else 
        {
            isStop = false;
        }

        return isStop;
    }

    private void Update()
    {
        if (!isStop)
        {
            _currentChrono += Time.deltaTime;
            chrono.text = "Chrono : " + floatToTimeString(_currentChrono);
            currentTime = _currentTimePerLevel - Time.time;
            countdown.text = "Countdown : " + floatToTimeString(currentTime);
        }
    }

    public string floatToTimeString(float time)
    {
        string prefix = "";
        if (time< 0) prefix = "-";
        time = Mathf.Abs(time);
        int minutes = (int) time / 60;
        int seconds = (int) time - 60 * minutes;
        int milliseconds = (int) (1000 * (time - minutes * 60 - seconds));
        return prefix + string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds );
    }
}
