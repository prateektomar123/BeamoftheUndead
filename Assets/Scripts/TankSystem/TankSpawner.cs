using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankModel[] tankModels; 
    private GameObject currentTank;                 

    private void Start()
    {
        SpawnTank(tankModels[0]);
    }
    public void SpawnTank(TankModel model)
    {
        if (currentTank != null)
        {
            Destroy(currentTank);
        }
        currentTank = Instantiate(model.tankPrefab, transform.position, Quaternion.identity);
        
    }
    public void SpawnTankByIndex(int index)
    {
        if (index >= 0 && index < tankModels.Length)
        {
            SpawnTank(tankModels[index]);
        }
        else
        {
            Debug.LogError("Invalid tank index!");
        }
    }
}