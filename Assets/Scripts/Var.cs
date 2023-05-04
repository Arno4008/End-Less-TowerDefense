using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Var : MonoBehaviour
{
    public static Var Instance;

    public int hp;
    public int hp_base;
    public int monnaie;
    public int level;
    public int xp;
    public int xp_need;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
