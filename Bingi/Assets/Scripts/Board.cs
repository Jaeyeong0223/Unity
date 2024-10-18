using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;
    [SerializeField]
    Transform tilesParent;

    List<Tile> tileList;

    Vector2Int puzzleSize = new Vector2Int(3, 3);
    float neighborTileDistance = 252.5f;       // 타일 크기에 맞게 조정
    public Vector3 EmptyTilePosition { set; get; }

    private IEnumerator Start()
    {
        tileList = new List<Tile>();
        SpawnTiles();
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

        yield return new WaitForEndOfFrame();

        tileList.ForEach(x => x.SetCorrectPosition());
        do
        {
            yield return StartCoroutine(OnSuffle());
        } while (!IsSolvable());
    }

    void SpawnTiles()
    {
        for (int y = 0; y < puzzleSize.y; ++y)
        {
            for (int x = 0; x < puzzleSize.x; ++x)
            {
                GameObject clone = Instantiate(tilePrefab, tilesParent);
                Tile tile = clone.GetComponent<Tile>();

                tile.Setup(this, puzzleSize.x * puzzleSize.y, y * puzzleSize.x + x + 1);

                tileList.Add(tile);
            }
        }
    }

    IEnumerator OnSuffle()
    {
        float current = 0;
        float percent = 0;
        float time = 1.5f;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            int index = Random.Range(0, puzzleSize.x * puzzleSize.y);
            tileList[index].transform.SetAsLastSibling();

            yield return null;
        }

        EmptyTilePosition = tileList[tileList.Count - 1].GetComponent<RectTransform>().localPosition;
    }

    public void IsMoveTile(Tile tile)
    {
        if (Vector3.Distance(EmptyTilePosition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
        {
            Vector3 goalPosition = EmptyTilePosition;

            EmptyTilePosition = tile.GetComponent<RectTransform>().localPosition;

            tile.OnMoveTo(goalPosition);
        }
    }

    public void IsGameOver()
    {
        List<Tile> tiles = tileList.FindAll(x => x.IsCorrected == true);

        Debug.Log("Correct Count : " + tiles.Count);
        if (tiles.Count == 8)
        {
            GameManager.Instance.hasBell = true;
            SceneManager.LoadScene("DogGod");
        }
    }

    bool IsSolvable()
    {
        int[] puzzleArray = new int[tileList.Count];
        for (int i = 0; i < tileList.Count; i++)
        {
            puzzleArray[i] = tileList[i].Numeric;
        }

        int inversionCount = GetInversionCount(puzzleArray);

        // 3x3 퍼즐의 경우, 교란 수가 짝수여야 해결 가능
        return inversionCount % 2 == 0;
    }

    int GetInversionCount(int[] array)
    {
        int inversionCount = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j] && array[i] != array.Length && array[j] != array.Length)
                {
                    inversionCount++;
                }
            }
        }
        return inversionCount;
    }
}

