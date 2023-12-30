using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMaker : MonoBehaviour
{
    [SerializeField] Transform[] T1C1;
    [SerializeField] Transform[] T2C1;
    [SerializeField] Transform[] T3C1;
    [SerializeField] Transform[] T4C1;
    [SerializeField] Transform[] T1C2;
    [SerializeField] Transform[] T2C2;
    [SerializeField] Transform[] T3C2;
    [SerializeField] Transform[] T4C2;

    [SerializeField] GameObject customerPrefab;
    [SerializeField] List<InventorySlot> inventorySlots;

    public static int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0 };

    private float time;
    [SerializeField] float timeForCustomer = 60f;
    [SerializeField] float timeForOrder = 60f;


    private void Start()
    {
        time = 50f;
        if (UpgradeVariables.upgradeCustomerSpawnRate)
        {
            timeForCustomer = 30f - (UpgradeVariables.day * 3f);
        }
        else
        {
            timeForCustomer = 60f - (UpgradeVariables.day * 5f);
        }

        if (UpgradeVariables.upgradeOrderTimeLimit)
        {
            timeForOrder = 90f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeForCustomer);
        time += Time.deltaTime;
        if (time >= timeForCustomer)
        {
            makeCustomer(findEmptyChair());
            time = 0;
        }
    }

    // returns the number of an available chair
    private int findEmptyChair()
    {
        List<int> emptyTableList = new List<int>();
        int emptyChairNumber = 0;
        int pickedChair = -1;
        if (UpgradeVariables.upgradeTables == true)
        {
            for (int i = 0; i < 8; i++)
            {
                if (arr[i] == 0)
                {
                    int chair = i;
                    emptyTableList.Add(chair);
                    emptyChairNumber++;
                }
            }
            if (emptyChairNumber > 0)
            {
                pickedChair = emptyTableList[UnityEngine.Random.Range(0, emptyChairNumber)];
            }
        }
        // loop if there are no additional chairs
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (arr[i] == 0)
                {
                    int chair = i;
                    emptyTableList.Add(chair);
                    emptyChairNumber++;
                }
            }
            if (emptyChairNumber > 0)
            {
                pickedChair = emptyTableList[UnityEngine.Random.Range(0, emptyChairNumber)];
            }
        }
        return pickedChair;
    }

    // if the chair is valid, create a customer with a waypoint path to the chair
    private void makeCustomer(int chair)
    {
        if (chair != -1)
        {
            arr[chair] = 1;
            GameObject customer = Instantiate(customerPrefab);
            customer.GetComponent<OrderMaker>().playerInventorySlots = inventorySlots;
            customer.GetComponent<CustomerManager>().tableNumber = chair;
            customer.GetComponent<CustomerManager>().clockStart = timeForOrder;

            switch (chair)
            {
                case 0:
                    customer.GetComponent<FollowPath>().Points = T1C1;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = false;
                    break;
                case 1:
                    customer.GetComponent<FollowPath>().Points = T2C1;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = false;
                    break;
                case 2:
                    customer.GetComponent<FollowPath>().Points = T3C1;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = true;
                    break;
                case 3:
                    customer.GetComponent<FollowPath>().Points = T4C1;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = true;
                    break;
                case 4:
                    customer.GetComponent<FollowPath>().Points = T1C2;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = true;
                    break;
                case 5:
                    customer.GetComponent<FollowPath>().Points = T2C2;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = true;
                    break;
                case 6:
                    customer.GetComponent<FollowPath>().Points = T3C2;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = false;
                    break;
                case 7:
                    customer.GetComponent<FollowPath>().Points = T4C2;
                    customer.GetComponent<FollowPath>().isSittingFacingLeft = false;
                    break;
            }
            customer.SetActive(true);
        }
    }
}