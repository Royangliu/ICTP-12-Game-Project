using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void resetVariables()
    {
        UpgradeVariables.money = 0f;
        UpgradeVariables.score = 0f;
        UpgradeVariables.upgradeTables = false;
        UpgradeVariables.upgradePlayerSpeed = false;
        UpgradeVariables.upgradeCustomerSpawnRate = false;
        UpgradeVariables.upgradePay = false;
        UpgradeVariables.upgradeOrderTimeLimit = false;
        UpgradeVariables.upgradeStations = false;
        UpgradeVariables.upgradeTrash = false;

        UpgradeVariables.day = 1;
    }

    public void goToFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}
