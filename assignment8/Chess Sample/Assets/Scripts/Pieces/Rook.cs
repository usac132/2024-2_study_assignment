using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rook.cs
public class Rook : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        // 위 방향
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(0, 1, i));
        }

        // 아래 방향
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(0, -1, i));
        }

        // 오른쪽 방향
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(1, 0, i));
        }

        // 왼쪽 방향
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(-1, 0, i));
        }

        return moves.ToArray();
        // ------
    }
}
