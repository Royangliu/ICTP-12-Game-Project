using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YourScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = UpgradeVariables.score.ToString();
    }
}
