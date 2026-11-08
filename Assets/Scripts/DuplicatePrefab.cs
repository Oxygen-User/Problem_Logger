using UnityEngine;

public class DuplicatePrefab : MonoBehaviour
{

    public GameObject prefab;
    public Transform parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Dupe()
    {
        
        Instantiate(prefab , parent , false);
    }
}