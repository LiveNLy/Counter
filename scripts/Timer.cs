using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [NonSerialized] public int CurrentTime = 0;
    [NonSerialized] public bool IsWorking = true;

    public event Action TimerDrowing;
    public event Action TimeStoping;
    public event Action TimeStarting;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsWorking == true)
        {
            TimeStoping?.Invoke();
        }
        else if (Input.GetMouseButtonDown(0) && IsWorking == false)
        {
            TimeStarting?.Invoke();
        }

        if (IsWorking == true)
            StartCoroutine(SetTime(0.5f));
        else if(IsWorking == false)
            StopAllCoroutines();
    }

    public IEnumerator SetTime(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int finishTime = 1000;

        for (int i = CurrentTime; i < finishTime; i++)
        {
            CurrentTime = i;
            TimerDrowing?.Invoke();
            yield return wait;
        }
    }
}