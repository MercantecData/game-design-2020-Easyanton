﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionModal : MonoBehaviour
{
    public Button Btn_StartMission;

    // Start is called before the first frame update
    void Start()
    {
        Btn_StartMission.onClick.AddListener(StartMission);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartMission()
    {
        gameObject.SetActive(false);
    }
}