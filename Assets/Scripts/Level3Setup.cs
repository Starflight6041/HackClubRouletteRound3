using UnityEngine;

public class Level3Setup : LevelSetup
{
    public GameManagement gameManager;
    public MapCreator mapCreator;
    public Racecar racecar;
    public Tourbus tourbus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapCreator.GetTile(5, 7).ChangePlaceable2(true);
        mapCreator.GetTile(7, 0).ChangePlaceable2(true);
        mapCreator.GetTile(7, 1).ChangePlaceable2(true);
        mapCreator.GetTile(8, 0).ChangePlaceable2(true);
        mapCreator.GetTile(8, 1).ChangePlaceable2(true);
        mapCreator.GetTile(9, 4).ChangePlaceable2(true);
        mapCreator.GetTile(4, 3).ChangeGoalStatus(true);
        mapCreator.GetTile(7, 7).ChangeGoalStatus(true);
        mapCreator.GetTile(8, 7).ChangeGoalStatus(true);
        mapCreator.GetTile(10, 7).ChangeGoalStatus(true);
        //mapCreator.GetTile(2, 5).ChangePlaceable2(true);
        gameManager.PlaceMapCar(0, 5, "racecar", 270);
        gameManager.PlaceMapCar(0, 6, "racecar", 270);
        racecar.SetCarAmount(2);
        tourbus.SetCarAmount(2);
        gameManager.SetGoalAmount(4);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
