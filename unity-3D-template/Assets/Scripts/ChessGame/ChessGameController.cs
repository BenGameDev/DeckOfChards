using System;
using UnityEngine;

[RequireComponent(typeof(PieceCreator))]
public class ChessGameController : MonoBehaviour
{
    [SerializeField] private BoardLayout startingBoardLayout;
    [SerializeField] private Board board;

    private PieceCreator pieceCreator;
    
    private void Awake()
    {
        SetDependencies();
    }

    private void SetDependencies()
    {
        pieceCreator = GetComponent<PieceCreator>();
    }

    private void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        CreatePiecesFromLayout(startingBoardLayout);

    }

    private void CreatePiecesFromLayout(BoardLayout layout)
    {
        for(int i = 0; i <layout.GetPiecesCount(); i++)
        {
            Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
            TeamColour team = layout.GetSquareTeamColourAtIndeX(i);
            string typeName = layout.GetSquarePieceNameAtIndex(i);

            Type type = Type.GetType(typeName);
            CreatePieceAndInitialize(squareCoords, team, type);
        }
    }

    private void CreatePieceAndInitialize(Vector2Int squareCoords, TeamColour team, Type type)
    {
        Piece newPiece = pieceCreator.CreatePiece(type).GetComponent<Piece>();
        newPiece.SetData(squareCoords, team, board);

        Material teamMaterial = pieceCreator.GetTeamMaterial(team);
        newPiece.SetMaterial(teamMaterial);

    }
}
