using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtraMove : MonoBehaviour, CardFunctions, IDropHandler
{
    public Board board;
    public ChessGameController controller;

    private void Awake()
    {
        
    }

    public void DiscardCard()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        PlayCard();
    }

    public void PlayCard()
    {
        //Functionality
        //Extra move on the turn
        //Set has moved to false
        board.pieceMoved = false;
        controller.activePlayer.GenerateAllPossibleMoves();
        
    }
}
