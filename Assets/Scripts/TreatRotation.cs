using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationsPerMinute;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationsPerMinute * 360 / 60 * Time.deltaTime, Space.World);
    }
}
