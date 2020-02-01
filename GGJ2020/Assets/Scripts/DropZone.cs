using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropZone : MonoBehaviour
{
    [SerializeField] Image buttonWhole;

    int numPiecesPlaced = 0;
    int totalPieceCount = 3;

    Button b;

    private void Awake()
    {
        b = GetComponent<Button>();
    }

    private void Start()
    {
        b.interactable = false;
    }

    public void PlacePiece()
    {
        numPiecesPlaced++;
        Check();
    }

    private void Check()
    {
        if (numPiecesPlaced < totalPieceCount) return;

        b.interactable = true;        
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
