using UnityEngine;

/*
*   Spawns customer groups and manages the customerGroup queue
*/

public class CustomerManager : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] GameObject customerGroupPrefab;
    [SerializeField] Transform spawnPoint;

    public void SpawnCustomerGroup(int groupSize)
    {
        if (groupSize < 2 || groupSize > 4)
        {
            Debug.Log("Invalid customer group size.");
            return;
        }

        GameObject groupObject = Instantiate(customerGroupPrefab, spawnPoint.position, spawnPoint.rotation);
        CustomerGroup groupScript = groupObject.GetComponent<CustomerGroup>();

        float spacing = .7f;    // distance between customers in the group

        for (int i = 0; i < groupSize; i++)
        {
            Vector3 offset = new Vector3(0, 0, i * spacing);
            GameObject customer = Instantiate(customerPrefab, spawnPoint.position + offset, Quaternion.identity, groupObject.transform);

            groupScript.AddCustomer(customer.GetComponent<Customer>());
        }
    }

    void Start()
    {
        SpawnCustomerGroup(Random.Range(2, 5));
    }
}
