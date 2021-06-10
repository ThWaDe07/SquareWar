using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private slot sloot;

    void Awake()
    {
        sloot = GameObject.FindObjectOfType<slot>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (sloot.coll == 1)
        {
            Destroy(this.gameObject);
        }
    }
}