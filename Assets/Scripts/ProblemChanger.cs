using UnityEngine;
using TMPro;

public class ProblemChanger : MonoBehaviour
{
    //Select parent from editor
    [Header("Parent Object")]
    public Transform parentObject;

    //choose imput field from editor
    [Header("Input Field")]
    public TMP_InputField ProblemIndexInputField;

    //make variables of current problems index and the child count of parent obj
    private int currentIndex = 0;
    private int childCount = 0;

    //update child count on start and choose active problem
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if(parentObject == null)
        {
            parentObject = this.transform;
        }

        UpdateChildCount();

        SetActiveProblem(currentIndex);
        
    }


    void Update()
    {
        childCount = parentObject.childCount;
    }


    public void UpdateChildCount()
    {
        childCount = parentObject.childCount;
    }

    //make a function to set active problem
    public void SetActiveProblem(int IndexToActivate)
    {
        if (childCount == 0) return;

        for(int i = 0; i < childCount; i++)
        {
            Transform child = parentObject.GetChild(i);

            child.gameObject.SetActive(i == IndexToActivate);
        }

        currentIndex = IndexToActivate;

        if (ProblemIndexInputField != null)
        {
            ProblemIndexInputField.text = (IndexToActivate + 1).ToString();
        }
    }


    //create functions for next and previous buttons
    public void NextProblem()
    {
        
        currentIndex++;
        if (currentIndex >= childCount)
        {
            currentIndex = 0;
        }

        SetActiveProblem(currentIndex);

    }

    public void PreviousProblem()
    {
        
        currentIndex--;
        if (currentIndex < 0 )
        {
            currentIndex = childCount - 1 ;
        }

        SetActiveProblem(currentIndex);

    }
    
    //get data from input field
    public void InputFieldUtilised()
    {
        
        if (ProblemIndexInputField == null || string.IsNullOrEmpty(ProblemIndexInputField.text)) return;

        if (int.TryParse(ProblemIndexInputField.text, out int targetIndex))
        {
            
            int actualIndex = targetIndex - 1;

            if (actualIndex >= 0 && actualIndex < childCount)
            {
                currentIndex = actualIndex;
                SetActiveProblem(currentIndex);

            }
            else
            {
                ProblemIndexInputField.text = (currentIndex +1).ToString();
            }
        }
    }
    



}
