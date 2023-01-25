using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanceController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        TractorController tractorController = other.GetComponent<TractorController>();
        if (tractorController != null)
        {
            tractorController.finish();
        }

        TractorController2 tractorController2 = other.GetComponent<TractorController2>();
        if (tractorController2 != null)
        {
            tractorController2.finish();
        }
    }
}

