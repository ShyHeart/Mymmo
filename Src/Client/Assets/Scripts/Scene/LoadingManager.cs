﻿using Services;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LoadingManager : MonoBehaviour
{

    public GameObject UITips;
    public GameObject UILoading;
    public GameObject UILogin;
    public Slider progressBar;
    public Text progressText;
    public Text progressNumbrer;

     IEnumerator Start()
    {
        log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.xml"));
        UnityLogger.Init();
        Common.Log.Init("Unity");
        Common.Log.Info("LoadingManager start");
        
        UITips.SetActive(true);
        UILoading.SetActive(false);
        UILogin.SetActive(false);
        yield return new WaitForSeconds(2f);
        UILoading.SetActive(true);
        yield return new WaitForSeconds(1f);
        UITips.SetActive(false);

        //yield return DataManager.Instance.LoadData();
        StartCoroutine(DataManager.Instance.LoadData());

        //Init basic services
        MapService.Instance.Init();
        UserService.Instance.Init();
        
       for (float i = 0; i < 100;)
       {
           i += Random.Range(0.1f,0.5f);
           progressBar.value = i;
           progressNumbrer.text = (int) i + "%";
           yield return new WaitForEndOfFrame();
       }

        UILoading.SetActive(false);
        UILogin.SetActive(true);
        yield return null;
    }
}