using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public Toggle toggle;
    public GameObject obj1;
    public GameObject obj2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggle);

        OnToggle(toggle.isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggle(bool check)
    {
        obj1.SetActive(!check);
        obj2.SetActive(!check);
    }
}
