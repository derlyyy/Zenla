using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public GameObject minion;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject minion = Instantiate(this.minion, transform.position, Quaternion.identity);
        }
    }
}
