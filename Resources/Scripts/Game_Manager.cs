﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public int num;
    public void nextScene()
    {
        SceneManager.LoadScene(num);
    }
}
