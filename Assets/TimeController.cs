using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] GameObject scoreRequirementTitle;
    [SerializeField] GameObject scoreRequirement;

    [SerializeField] GameObject scoreTitle;
    [SerializeField] GameObject score;

    [SerializeField] GameObject WIN;
    [SerializeField] GameObject COUPON;
    [SerializeField] GameObject LOSE;

    [SerializeField] GameObject RESTART;
    [SerializeField] GameObject QUIT;

    private float time = 0;

    private bool shownAllText = false;

    private bool shown1 = false;
    private bool shown2 = false;
    private bool shown3 = false;


    // Update is called once per frame
    void Update()
    {
        if (!shownAllText)
        {
            time += Time.deltaTime;
            if (time >= 1 && !shown1)
            {
                scoreRequirement.SetActive(true);
                scoreRequirementTitle.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Plonk");
                shown1 = true;
            }
            if (time >= 2 && !shown2)
            {
                scoreTitle.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Plonk");
                shown2 = true;
            }
            if (time >= 4 && !shown3)
            {
                score.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Plonk");
                shown3 = true;
            }
            if (time >= 5)
            {
                if (UpgradeVariables.score >= 250)
                {
                    WIN.SetActive(true);
                    COUPON.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Yay");
                }
                else
                {
                    LOSE.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Aww");
                }
                RESTART.SetActive(true);
                QUIT.SetActive(true);
                shownAllText = true;
            }
        }
    }
}
