using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public LevelManager LevelManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearScene()
    {
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.tag != "MainCamera" && obj.tag != "Player")
            {
                Destroy(obj);
            }
        }
    }
}

