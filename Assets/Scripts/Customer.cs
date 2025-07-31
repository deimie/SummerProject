using UnityEngine;

/*
*   Lives on customer prefab, holds the state of customers (waiting, sitting, ordering) and the logic for performing each state
*/

public class Customer : MonoBehaviour
{
    [SerializeField] string state;

    public CustomerGroup group;

    bool hasOrderedDrink = false;
    bool hasOrderedFood = false;

    public void AssignGroup(CustomerGroup g)
    {
        group = g;
    }
    void Update()
    {
        switch (state)
        {
            case "Waiting":
                Waiting();
                break;
            case "Seated":
                break;
            case "Leaving":
                break;
        }
    }

    void Waiting()
    {
        // display popup above head
        // become clickable for table assignment (unless tables are full)
    }
}
