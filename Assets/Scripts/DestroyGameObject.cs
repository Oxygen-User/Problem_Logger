using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public GameObject OBJtoDestroy;
    public void Destroy()
    {
        Destroy(OBJtoDestroy);
    }
}