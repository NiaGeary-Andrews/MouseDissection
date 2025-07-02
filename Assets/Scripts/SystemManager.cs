using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public enum System
    {
        Integumentary,
        Muscular,
        Skeletal
    }
    private GameObject currentModel;
    public GameObject[] modelPrefabs; //prefabs for each system
    private GameObject[] instantiatedModels; // Instantiated models
    public ScrollAndZoom MovementManager;

    public Transform spawnPoint;

    void Start()
    {
        MovementManager = MovementManager.GetComponent<ScrollAndZoom>();
        instantiatedModels = new GameObject[modelPrefabs.Length];

        for (int i = 0; i < modelPrefabs.Length; i++)
        {
            if (modelPrefabs[i] != null)
            {
                instantiatedModels[i] = Instantiate(
                    modelPrefabs[i],
                    spawnPoint ? spawnPoint.position : Vector3.zero,
                    Quaternion.identity
                );
                instantiatedModels[i].SetActive(false);
            }
        }

        // Optionally load a default system
        ChangeSystem((int)System.Skeletal);
    }

    public void ChangeSystem(int systemIndex)
    {
        if (systemIndex < 0 || systemIndex >= instantiatedModels.Length)
        {
            Debug.LogWarning("Invalid system index.");
            return;
        }

        if (currentModel != null)
            currentModel.SetActive(false);

        currentModel = instantiatedModels[systemIndex];

        if (currentModel != null)
            currentModel.SetActive(true);
            MovementManager.changeTargetObject(currentModel.transform);

    }
}
