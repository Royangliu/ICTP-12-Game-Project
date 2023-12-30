using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject KitchenCamera;
    public GameObject MainCamera;
    public bool IsMainCamera = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb.position.y >= 1.6 && IsMainCamera == true)
        {
            MainCamera.SetActive(false);
            KitchenCamera.SetActive(true);
            IsMainCamera = false;
        }
        else if (rb.position.y < 1.6 && IsMainCamera == false)
        {
            KitchenCamera.SetActive(false);
            MainCamera.SetActive(true);
            IsMainCamera = true;
        }
    }
}
