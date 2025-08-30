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
        mapCreator.GetTile(9, 1).ChangeGoalStatus(true);
        mapCreator.GetTile(7, 0).ChangeGoalStatus(true);
        mapCreator.GetTile(0, 0).ChangePlaceable2(true);
        mapCreator.GetTile(0, 1).ChangePlaceable2(true);
        mapCreator.GetTile(0, 2).ChangePlaceable2(true);
        mapCreator.GetTile(0, 3).ChangePlaceable2(true);
        mapCreator.GetTile(0, 4).ChangePlaceable2(true);
        mapCreator.GetTile(0, 5).ChangePlaceable2(true);
        mapCreator.GetTile(1, 0).ChangePlaceable2(true);
        mapCreator.GetTile(1, 1).ChangePlaceable2(true);
        mapCreator.GetTile(1, 2).ChangePlaceable2(true);
        mapCreator.GetTile(1, 3).ChangePlaceable2(true);
        mapCreator.GetTile(1, 4).ChangePlaceable2(true);
        mapCreator.GetTile(1, 5).ChangePlaceable2(true);
        //mapCreator.GetTile(2, 0).ChangePlaceable2(true);
        //mapCreator.GetTile(2, 1).ChangePlaceable2(true);
        mapCreator.GetTile(2, 2).ChangePlaceable2(true);
        //mapCreator.GetTile(2, 3).ChangePlaceable2(true);
        //mapCreator.GetTile(2, 4).ChangePlaceable2(true);
        //mapCreator.GetTile(2, 5).ChangePlaceable2(true);
        gameManager.PlaceMapCar(0, 5, "racecar", 270);
        gameManager.PlaceMapCar(0, 6, "racecar", 270);
        racecar.SetCarAmount(3);
        tourbus.SetCarAmount(2);
        gameManager.SetGoalAmount(2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
