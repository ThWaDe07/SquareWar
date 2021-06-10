using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxscale : MonoBehaviour
{
    public BoxCollider2D box;
    
    void Start()
    {
        box = box.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        box.size = new Vector3(transform.GetChild(0).localScale.x - 0.1f, transform.GetChild(0).localScale.y - 0.1f, 1);
        box.offset = new Vector3(transform.GetChild(0).localPosition.x, transform.GetChild(0).localPosition.y, 1);
    }
}
