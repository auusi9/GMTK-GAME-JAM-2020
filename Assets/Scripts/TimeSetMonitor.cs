using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSetMonitor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time.SetText("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    }
}
