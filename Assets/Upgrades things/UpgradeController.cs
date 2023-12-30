using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] GameObject TrashSlot;
    [SerializeField] GameObject ExtraChairs;

    void Awake()
    {
        if (UpgradeVariables.upgradeTrash)
        {
            TrashSlot.SetActive(true);
        }
        if (UpgradeVariables.upgradeTables)
        {
            ExtraChairs.SetActive(true);
        }
    }
}
