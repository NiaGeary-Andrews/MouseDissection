using UnityEngine;

public class ClickableObject : MonoBehaviour
{

    private Outline outline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Outline component
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            Debug.LogError("Outline component not found on " + gameObject.name);
        }
        outline.enabled = false;
    }

    void OnMouseEnter()
    {
        if (outline != null)
        {
            Debug.Log(this);
            outline.OutlineColor = Color.green;
            outline.enabled = true;
        }
    }

    void OnMouseExit()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        outline.OutlineColor = Color.red;
        outline.enabled = true;
    }
}
