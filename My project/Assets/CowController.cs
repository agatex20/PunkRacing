using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TractorController tractorController = other.GetComponent<TractorController>();
        if(tractorController!=null)
        {
            tractorController.cowCollected();
            gameObject.SetActive(false);
        }

        TractorController2 tractorController2 = other.GetComponent<TractorController2>();
        if (tractorController2 != null)
        {
            tractorController2.cowCollected();
            gameObject.SetActive(false);
        }
    }
    
}
