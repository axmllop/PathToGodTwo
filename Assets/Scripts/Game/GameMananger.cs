using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    public static GameMananger Intance;

    public bool isGameStart
    {
        get;


        set;
        
    }
    public bool isGameOver
    {
        set;
        get;
    }
    private void Awake()
    {
        Intance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
