using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject NextButton;

    private int currentIndex = 0;

    private void Update()
    {
        if (currentIndex == 0)
            previousButton.SetActive(false);
        else
            previousButton.SetActive(true);
        
        if (currentIndex == panels.Length - 1)
            NextButton.SetActive(false);
        else
            NextButton.SetActive(true);
    }

    public void nextPage()
    {
        if (currentIndex < panels.Length)
        {
            panels[currentIndex].SetActive(false);
            currentIndex++;
            panels[currentIndex].SetActive(true);
        }
    }

    public void previousPage()
    {
        if (currentIndex > 0) 
        {
            panels[currentIndex].SetActive(false);
            currentIndex--;
            panels[currentIndex].SetActive(true);
        }
    }
}
