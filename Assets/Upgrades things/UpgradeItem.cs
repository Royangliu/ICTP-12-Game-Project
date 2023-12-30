using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    [SerializeField] float cost;
    [SerializeField] GameObject soldSign;

    private UpgradesManager currentManager;

    // Start is called before the first frame update
    void Start()
    {
        currentManager = FindObjectOfType<UpgradesManager>();
        checkIfBought();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfBought();
    }

    // please change according to upgrade
    public void getUpgrade()
    {
        if (currentManager.money >= cost)
        {
            currentManager.money -= cost;
            // add declaration statement
        }
    }

    // please change according to upgrade
    private void checkIfBought()
    {
        if (true) // change
        {
            GameObject sign = Instantiate(soldSign);
            sign.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }
}
