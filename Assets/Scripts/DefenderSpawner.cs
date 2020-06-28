using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender;

    private void OnMouseDown()
    {
        AttemptPlaceDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptPlaceDefender(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        return worldPos;
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, SnapToGrid(worldPos), Quaternion.identity);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }
}
