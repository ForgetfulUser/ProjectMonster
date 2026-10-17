using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player_GO;
    public List<GameArea> GameAreaList = new List<GameArea>();
    // Player References
    [HideInInspector] public PlayerController PlayerController;
    [HideInInspector] public MonsterTamer PlayerTamer;

    [HideInInspector] public List<MonsterData> LoadedMonsters = new List<MonsterData>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Player_GO); // Won't be needed if Changed to prefab
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Setup Player
        PlayerController = Player_GO.GetComponent<PlayerController>();
        PlayerTamer = Player_GO.GetComponent<MonsterTamer>();
        DontDestroyOnLoad(Player_GO);
        LoadedMonsters = MonsterLoader.LoadAllMonsterDatas();

        // Load Areas
        foreach(GameArea area in GameAreaList)
        {
            area.LoadArea();
        }
    }

    public List<MonsterData> GetMonsterList(SearchParameter searchParams)
    {
        List<MonsterData> finalMonsterList = new List<MonsterData>();
        foreach(MonsterData monster in LoadedMonsters)
        {
            bool monTypeCheck = false;
            bool elementCheck = false;
            bool rarityCheck = false;
            bool healthCheck = false;
            bool physAtkCheck = false;
            bool physDefCheck = false;
            bool magAtkCheck = false;
            bool magDefCheck = false;
            bool speedCheck = false;

            // Name Check
            if (searchParams.Name != "" && searchParams.Name == monster.Name)
            {
                Debug.Log("HE");
                finalMonsterList.Clear();
                finalMonsterList.Add(monster);
                break;
            }
            else if(searchParams.Name != "")
            {
                continue;
            }
            // Monster Type Check
            {
                // Type 1 
                if (searchParams.MonsterType1 == MonsterType.None)
                {
                    monTypeCheck = true;
                }
                else if (searchParams.MonsterType1 == monster.MonsterType1)
                {
                    // Type 2
                    if (searchParams.MonsterType2 == MonsterType.None)
                    {
                        monTypeCheck = true;
                    }
                    else if (searchParams.MonsterType2 == monster.MonsterType2)
                    {
                        monTypeCheck = true;
                    }
                }
            }

            // Element Type Check
            {
                // Type 1
                if(searchParams.Element1 == ElementType.None)
                {
                    elementCheck = true;
                }
                else if (searchParams.Element1 == monster.Element1)
                {
                    // Type 2
                    if (searchParams.Element2 == ElementType.None)
                    {
                        elementCheck = true;
                    }
                    else if (searchParams.Element2 == monster.Element2)
                    {
                        elementCheck = true;
                    }
                }
            }

            // Rarity Type Check
            if (searchParams.RarityMinMax.x <= (int)monster.MonsterRarity 
                && (int)monster.MonsterRarity <= searchParams.RarityMinMax.y)
            {
                rarityCheck = true;
            }

            // Health Check
            if (searchParams.HealthMinMax.x <= monster.Health.y 
                && monster.Health.y <= searchParams.HealthMinMax.y)
            {
                healthCheck = true;
            }

            // Physical Attack Check
            if (searchParams.PhysAtkMinMax.x <= monster.PhysicalAttack 
                && monster.PhysicalAttack <= searchParams.PhysAtkMinMax.y)
            {
                physAtkCheck = true;
            }

            // Physical Defense Check
            if (searchParams.PhysDefMinMax.x <= monster.PhysicalDefense
                && monster.PhysicalDefense <= searchParams.PhysDefMinMax.y)
            {
                physDefCheck = true;
            }

            // Magical Attack Check
            if (searchParams.MagAtkMinMax.x <= monster.MagicalAttack
                && monster.MagicalAttack <= searchParams.MagAtkMinMax.y)
            {
                magAtkCheck = true;
            }

            // Magical Defense Check
            if (searchParams.MagDefMinMax.x <= monster.MagicalDefense
                && monster.MagicalDefense <= searchParams.MagDefMinMax.y)
            {
                magDefCheck = true;
            }

            // Speed Check
            if (searchParams.SpeedMinMax.x <= monster.Speed
                && monster.Speed <= searchParams.SpeedMinMax.y)
            {
                speedCheck = true;
            }

            // Grand Check
            if (monTypeCheck && elementCheck && rarityCheck && healthCheck && physAtkCheck
                && physDefCheck && magAtkCheck && magDefCheck && speedCheck)
            {
                finalMonsterList.Add(monster);
            }
        }
        return finalMonsterList;
    }
}
