using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CustomerManager : MonoBehaviour
{
    [HideInInspector] public float clockStart;
    private bool pastLimit = false;
    private bool hasMadeOrder = false;
    private bool orderSuccess = false;
    private float moneyPerOrder = 10f;
    public int tableNumber;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FollowPath>().isWalking = true;
        if (UpgradeVariables.upgradePay)
        {
            moneyPerOrder = 15f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<FollowPath>().isWalking == false)
        {
            clockStart -= Time.deltaTime;
            if (hasMadeOrder == false)
            {
                GetComponent<OrderMaker>().makeOrder();
                hasMadeOrder = true;
            }
        }
        
        if ((clockStart <= 0 || orderSuccess) && pastLimit == false)
        {
            GetComponent<OrderMaker>().destroyOrder();
            GetComponent<FollowPath>().isWalkingBack = true;
            GetComponent<FollowPath>().isWalking = true;
            pastLimit = true;
        }

        if (pastLimit == true && GetComponent<FollowPath>().isWalking == false)
        {
            CustomerMaker.arr[tableNumber] = 0;
            Destroy(gameObject);
        }

        if (clockStart > 0 && hasMadeOrder && !pastLimit)
        {
            GetComponentInChildren<TextMeshPro>().text = string.Format("{0:0}", clockStart);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<FollowPath>().isWalking == false && hasMadeOrder)
        {
            if (GetComponent<OrderMaker>().canSell())
            {
                orderSuccess = true;
                UpgradeVariables.money += moneyPerOrder;
                UpgradeVariables.score += moneyPerOrder;
                FindObjectOfType<AudioManager>().Play("Money");
            }
        }
    }
}
