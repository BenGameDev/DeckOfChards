using UnityEngine;

[CreateAssetMenu(fileName = "ChessPieceStats", menuName = "Scriptable Objects/ChessPieceStats")]
public class ChessPieceStats : ScriptableObject
{
    int numberOfSpaces;
    
    int pointCount;
    string pieceName;
}
