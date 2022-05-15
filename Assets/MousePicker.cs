using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicker : MonoBehaviour
{
    //define at component level
    private new Camera camera;
    private RaycastHit hit;
    private GameObject hitObject;

    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        { 
            var prsObject = hitObject;
            hitObject = hit.collider.gameObject;

            while(hitObject.transform.root != hitObject.transform)
            {
                var btn = hitObject.GetComponent<ButtonEvent>();

                if (btn != null)
                    break;
                hitObject = hitObject.transform.parent.gameObject;
            }

            if (prsObject != hitObject)
            {
                ButtonEvent btn;
                if (prsObject != null)
                {
                    btn = prsObject.GetComponent<ButtonEvent>();
                    if (btn != null)
                    {
                        btn.Hover = false;
                    }
                }
                btn = hitObject.GetComponent<ButtonEvent>();
                if (btn != null)
                {
                    btn.Hover = true;
                }
            }

        }
        else 
        {
            if (hitObject != null)
            {
                var btn = hitObject.GetComponent<ButtonEvent>();
                if (btn != null)
                {
                    btn.Hover = false;
                }
                hitObject = null;
            }
        }
    }
}
