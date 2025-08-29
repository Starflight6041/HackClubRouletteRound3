using UnityEngine;

public class Level1Setup : LevelSetup
{
    public GameManagement gameManager;
    public MapCreator mapCreator;
    public Racecar racecar;
    public Tourbus tourbus;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public override void SetLevelGoals()
    {

        mapCreator.GetTile(6, 5).ChangeGoalStatus(true);
        mapCreator.GetTile(3, 3).ChangePlaceable2(true);
        mapCreator.GetTile(4, 3).ChangePlaceable2(true);
        racecar.SetCarAmount(1);
        tourbus.SetCarAmount(1);
        gameManager.SetGoalAmount(1);
        
        
        //GetTile(3, 4).ChangePlaceable(true);
        // set places to be goals specifically for level one

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
