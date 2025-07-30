using System.Collections.Generic;
using UnityEngine;

/*
*   Lives on group prefab and manages the list of customers in the group
*/

public class CustomerGroup : MonoBehaviour
{
    [SerializeField] List<Customer> customers = new List<Customer>();

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
        customer.AssignGroup(this);
    }
}
