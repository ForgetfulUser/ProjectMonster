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
        return SearchFilterSystem.FilterMonsterDatas(LoadedMonsters, searchParams);
    }
}
