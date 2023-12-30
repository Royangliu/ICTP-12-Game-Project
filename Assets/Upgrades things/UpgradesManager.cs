using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public float money = 0f;
    public float score = 0f;
    public bool upgradeTables = false;
    public bool upgradePlayerSpeed = false;
    public bool upgradeCustomerSpawnRate = false;
    public bool upgradePay = false;
    public bool upgradeOrderTimeLimit = false;
    public bool upgradeStations = false;
    public bool upgradeTrash = false;

    public int day = 1;

    public static UpgradesManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
