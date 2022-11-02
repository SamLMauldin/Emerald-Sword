using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerBattle : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("StateController").GetComponent<PlayerMovement>()._triggerBattle = true;
        this.gameObject.SetActive(false);
    }
}
