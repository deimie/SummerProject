using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmployeePlacement : MonoBehaviour
{
    private GameObject currentEmployee; // The employee GameObject currently being placed in the scene
    [SerializeField] private Camera playerCamera; // Reference to the camera used to calculate the screen-to-world ray
    [SerializeField] private Transform spawnPoint; // Default area the employee spawns
    [SerializeField] private LayerMask employeeLayer; // Reference to the employee layer
    [SerializeField] private LayerMask groundLayer; // Reference to the ground layer

    private GameObject selectedEmployee; // The employee currently being moved


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray camray = playerCamera.ScreenPointToRay(mousePos);

        // Click to select an employee
        if (Mouse.current.leftButton.wasPressedThisFrame && selectedEmployee == null)
        {
            if (Physics.Raycast(camray, out RaycastHit hit, 100f, employeeLayer))
            {
                selectedEmployee = hit.collider.gameObject;
            }
        }
        // Move the selected employee
        else if (selectedEmployee != null)
        {
            if (Physics.Raycast(camray, out RaycastHit hitInfo, 100f, groundLayer))
            {
                selectedEmployee.transform.position = hitInfo.point;

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    selectedEmployee = null; // Finalize placement
                }
            }
        }
    }



    public void SetEmployeeToPlace(GameObject employee)
    {
        Ray ray = new Ray(spawnPoint.position + Vector3.up * 5f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f, groundLayer))
        {
            // Create the employee at origin temporarily (inactive to avoid flicker)
            GameObject temp = Instantiate(employee, Vector3.zero, Quaternion.identity);
            temp.SetActive(false);

            Collider col = temp.GetComponentInChildren<Collider>();
            float yOffset = 0f;

            if (col != null)
            {
                yOffset = col.bounds.extents.y;
            }
            else
            {
                Debug.LogWarning("No collider found on employee prefab.");
            }

            Destroy(temp); // destroy the temporary one

            // Final spawn with Y offset so it sits on the ground
            Vector3 finalSpawnPos = hit.point + Vector3.up * yOffset;
            GameObject newEmployee = Instantiate(employee, finalSpawnPos, Quaternion.identity);

            selectedEmployee = newEmployee;
        }
        else
        {
            Debug.LogWarning("Spawn point is not above the ground. Raycast failed.");
        }


    }

}
