using System.Collections;
using TMPro;
using UnityEngine;


public class ClickableObject : MonoBehaviour
{

    private Outline outline;

    [Header("Strings")]
    public string objectName;
    public string objectDescription;

    [Header("Prefabs")]
    public GameObject FloatingTextPrefab;

    [Header("Managers")]
    public UIManager UIManager;


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

        UIManager = UIManager.GetComponent<UIManager>();
    }

    void OnMouseEnter()
    {
        if (outline != null)
        {
            Debug.Log(this);
            outline.OutlineColor = Color.green;
            outline.enabled = true;
            //ShowFloatingText(objectName);
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
        UIManager.UpdateTitleText(objectName + ": "+ objectDescription);
        SoundManager.PlaySound(SoundType.OBJECTSELECT);
    }

    // Adds floating text on where you have just clicked
    private void ShowFloatingText(string text)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0.1f, 0.1f, 0));
        //GameObject floatingTextInstance = Instantiate(FloatingTextPrefab, screenPosition, Quaternion.identity, );
        GameObject floatingTextInstance = Instantiate(FloatingTextPrefab, GameObject.Find("Canvas").transform);
        floatingTextInstance.GetComponentInChildren<TextMeshProUGUI>().text = text;

        RectTransform rectTransform = floatingTextInstance.GetComponent<RectTransform>();
        rectTransform.position = screenPosition;

        StartCoroutine(FadeOutAndDestroy(floatingTextInstance, 2.0f));
    }

    private IEnumerator FadeOutAndDestroy(GameObject floatingTextInstance, float duration)
    {
        TextMeshProUGUI tmp = floatingTextInstance.GetComponentInChildren<TextMeshProUGUI>();
        Color originalColor = tmp.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            tmp.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        Destroy(floatingTextInstance);
    }
}
