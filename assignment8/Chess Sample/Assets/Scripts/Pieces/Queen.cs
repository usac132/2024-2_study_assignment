using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        // Rook 방향
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(0, 1, i));    // 위
            moves.Add(new MoveInfo(0, -1, i));   // 아래
            moves.Add(new MoveInfo(1, 0, i));    // 오른쪽
            moves.Add(new MoveInfo(-1, 0, i));   // 왼쪽
        }

        // Bishop 방향
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(1, 1, i));    // 오른쪽 위
            moves.Add(new MoveInfo(1, -1, i));   // 오른쪽 아래
            moves.Add(new MoveInfo(-1, 1, i));   // 왼쪽 위
            moves.Add(new MoveInfo(-1, -1, i));  // 왼쪽 아래
        }

        return moves.ToArray();
        // ------
    }
}