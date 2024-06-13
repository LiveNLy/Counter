
using TMPro;
using UnityEngine;

public class TimeCounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TimeCounter _timer;

    private void Start()
    {
        _text.text = "";
    }

    private void OnEnable()
    {
        _timer.TimerDrowing += DisplayTimer;
    }

    private void OnDisable()
    {
        _timer.TimerDrowing -= DisplayTimer;
    }

    public void DisplayTimer(int number)
    {
        _text.text = number.ToString();
    }
}