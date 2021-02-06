using TMPro;
using UnityEngine;


public class Chrono : MonoBehaviour
{
    [SerializeField] private float timePerLevel; // temps du compte à rebours en secondes
    [SerializeField] private TextMeshProUGUI  countdown; 
    [SerializeField] private TextMeshProUGUI  chrono;
    private float _currentTimePerLevel;
    private float _currentChrono;

    private bool stop;

    private void Start()
    {
        stop = false;
        _currentTimePerLevel = timePerLevel;
    }

    public void ResetChrono()
    {
        _currentChrono = 0;
    }

    public void ResetCountdown()
    {
        _currentTimePerLevel = timePerLevel;
    }

    public bool Stop()
    {
        if(_currentTimePerLevel <= 0)
        {
            stop = true;
        }
        else 
        {
            stop = false;
        }

        return stop;
    }

    private void Update()
    {
        if (!stop)
        {
            _currentChrono += Time.deltaTime;
            chrono.text = "Chrono : " + floatToTimeString(_currentChrono);
            countdown.text = "Countdown : " + floatToTimeString(_currentTimePerLevel - Time.time);
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
