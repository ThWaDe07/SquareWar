using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public int i1 = 1;
    public int i2 = 1;

    public void obj11()
    {
        soundmanager.PlaySound("menuclick");
        i1++;
        if (i1 == 1) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 0)); } else
            if (i1 == 2) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 0)); } else
                if (i1 == 3) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 0, 255)); } else 
                    if  (i1 == 4) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 255)); } else 
                        if  (i1 == 5) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 255)); } else 
                            if  (i1 == 6) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 0)); } else 
                               if  (i1 == 7) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 255)); } else
                                    if (i1 == 8) { i1 = 1; obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 0)); }
    }

    public void obj22()
    {
        soundmanager.PlaySound("menuclick");
        i2++;
        if (i2 == 1) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 0)); } else
            if (i2 == 2) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 0)); } else
                if (i2 == 3) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 0, 255)); } else
                    if (i2 == 4) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 255)); } else
                        if (i2 == 5) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 255)); } else
                            if (i2 == 6) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 0)); } else
                                if (i2 == 7) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 255)); } else
                                    if (i2 == 8) { i2 = 1; obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 0)); }
    }

    public void Load()
    {
        if (i1 == 1) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 0)); }
        else if (i1 == 2) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 0)); }
        else if (i1 == 3) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 0, 255)); }
        else if (i1 == 4) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 255)); }
        else if (i1 == 5) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 255)); }
        else if (i1 == 6) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 0)); }
        else if (i1 == 7) { obj1.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 255)); }

        if (i2 == 1) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 0)); }
        else if (i2 == 2) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 0)); }
        else if (i2 == 3) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 0, 255)); }
        else if (i2 == 4) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(0, 255, 255)); }
        else if (i2 == 5) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 0, 255)); }
        else if (i2 == 6) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 0)); }
        else if (i2 == 7) { obj2.GetComponentInChildren<Renderer>().sharedMaterial.SetColor("_Color", new Color(255, 255, 255)); }
    }
}
