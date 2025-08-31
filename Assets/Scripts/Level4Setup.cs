using UnityEngine;

public class Level4Setup : LevelSetup
{
    public GameManagement gameManager;
    public MapCreator mapCreator;
    public Racecar racecar;
    public Tourbus tourbus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapCreator.GetTile(5, 3).SetRotator(90);
        mapCreator.GetTile(0, 1).ChangePlaceable2(true);
        mapCreator.GetTile(0, 2).ChangePlaceable2(true);
        mapCreator.GetTile(0, 3).ChangePlaceable2(true);
        mapCreator.GetTile(1, 1).ChangePlaceable2(true);
        mapCreator.GetTile(1, 2).ChangePlaceable2(true);
        mapCreator.GetTile(1, 3).ChangePlaceable2(true);
        mapCreator.GetTile(2, 1).ChangePlaceable2(true);
        mapCreator.GetTile(2, 2).ChangePlaceable2(true);
        mapCreator.GetTile(2, 3).ChangePlaceable2(true);
        mapCreator.GetTile(3, 3).ChangeGoalStatus(true);
        mapCreator.GetTile(6, 0).ChangePlaceable2(true);
        mapCreator.GetTile(5, 0).ChangePlaceable2(true);
        mapCreator.GetTile(8, 1).ChangePlaceable2(true);
        mapCreator.GetTile(8, 2).ChangePlaceable2(true);
        mapCreator.GetTile(8, 3).ChangePlaceable2(true);
        mapCreator.GetTile(9, 1).ChangePlaceable2(true);
        mapCreator.GetTile(9, 2).ChangePlaceable2(true);
        mapCreator.GetTile(9, 3).ChangePlaceable2(true);
        mapCreator.GetTile(10, 7).ChangeGoalStatus(true);
        mapCreator.GetTile(6, 1).SetRotator(180);

        
        
        racecar.SetCarAmount(1);
        tourbus.SetCarAmount(1);
        gameManager.SetGoalAmount(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
