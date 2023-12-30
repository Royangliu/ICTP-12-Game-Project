using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFinalDay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (UpgradeVariables.day == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
