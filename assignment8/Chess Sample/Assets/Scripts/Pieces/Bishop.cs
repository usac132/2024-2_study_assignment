using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        // 오른쪽 위
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(1, 1, i));
        }

        // 오른쪽 아래
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(1, -1, i));
        }

        // 왼쪽 위
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(-1, 1, i));
        }

        // 왼쪽 아래
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(-1, -1, i));
        }

        return moves.ToArray();
        // ------
    }
}