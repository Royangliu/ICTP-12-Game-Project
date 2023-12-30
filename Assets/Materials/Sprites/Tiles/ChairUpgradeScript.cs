using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairUpgradeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (UpgradeVariables.upgradeTables)
        {
            gameObject.SetActive(true);
        }
    }
}
