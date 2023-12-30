using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementIncrease : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float cost;
    [SerializeField] GameObject soldSign;
    [SerializeField] GameObject text;


    // Start is called before the first frame update
    void Start()
    {
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
        if (UpgradeVariables.money >= cost)
        {
            text.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Money");
            UpgradeVariables.money -= cost;
            UpgradeVariables.upgradePlayerSpeed = true;
        }
    }

    // please change according to upgrade
    private void checkIfBought()
    {
        if (UpgradeVariables.upgradePlayerSpeed) // change
        {
            GameObject sign = Instantiate(soldSign);
            sign.transform.position = transform.position;
            sign.transform.SetParent(transform.parent);
            gameObject.SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.SetActive(false);
    }
}