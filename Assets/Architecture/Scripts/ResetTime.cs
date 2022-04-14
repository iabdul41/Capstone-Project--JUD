using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTime : MonoBehaviour
{
    [SerializeField]float time = 1;
    private void OnEnable()
    {
        Invoke("Disable", time);
    }

    void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
