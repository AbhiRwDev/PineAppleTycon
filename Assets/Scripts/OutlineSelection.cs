using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    public GameObject informationPanel;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
   
    [Header("Outline Settings")]
    public Color highlightColor = Color.magenta;
    public float highlightWidth = 7.0f;

    private bool isDeselected = false;

    
    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            if (!isDeselected)
            {
                if (highlight != selection)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = false;
                    informationPanel.SetActive(false);
                }
                highlight = null;
            }
            isDeselected = false;
        }

        // Raycast only when the mouse is over the game window
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
           
            if (highlight.CompareTag("Tile"))
            {
               
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    informationPanel.SetActive(true);
                    informationPanel.transform.position = highlight.transform.position;
                    informationPanel.transform.LookAt(this.gameObject.transform);
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    outline.OutlineColor = highlightColor;
                    outline.OutlineWidth = highlightWidth;
                }
            }
            else
            {
               
                highlight = null;
            }
        }

       
    }
}
