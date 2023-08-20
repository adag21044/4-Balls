using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputControl : MonoBehaviour
{
  
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                string layerName = GetTouchedObjectLayerName(touch.position);
                if (!string.IsNullOrEmpty(layerName))
                {
                    Debug.Log("Dokunulan Nesnenin Layer Adı: " + layerName);
                }
            }
        }
    }

    public static string GetTouchedObjectLayerName(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return LayerMask.LayerToName(hit.collider.gameObject.layer);
        }

        return null;
    }
}