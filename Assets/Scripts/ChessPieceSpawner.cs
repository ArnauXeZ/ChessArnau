using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessboardManager : MonoBehaviour
{
    public GameObject chessPiecePrefab; // Prefab del sprite de la ficha de ajedrez.
    public float spawnInterval = 2.0f; // Intervalo de tiempo entre la generaci�n de fichas.

    private List<Transform> tiles = new List<Transform>();
    private List<int> availableTileIndices = new List<int>();

    void Start()
    {
        // No generamos el tablero, ya que lo suponemos existente.
        GenerateTileIndices();
        StartCoroutine(SpawnChessPieces());
    }

    void GenerateTileIndices()
    {
        for (int i = 0; i < 64; i++)
        {
            availableTileIndices.Add(i);
        }
    }

    IEnumerator SpawnChessPieces()
    {
        while (availableTileIndices.Count > 0)
        {
            int randomIndex = Random.Range(0, availableTileIndices.Count);
            int tileIndex = availableTileIndices[randomIndex];

            // Calcula la posici�n de la casilla en funci�n del �ndice.
            float row = tileIndex / 8;
            float col = tileIndex % 8;
            Vector3 position = new Vector3(col, -row, 0);

            Instantiate(chessPiecePrefab, position, Quaternion.identity);

            availableTileIndices.RemoveAt(randomIndex);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}



