using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        // ������ ��
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(1, 1, i));
        }

        // ������ �Ʒ�
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(1, -1, i));
        }

        // ���� ��
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(-1, 1, i));
        }

        // ���� �Ʒ�
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(-1, -1, i));
        }

        return moves.ToArray();
        // ------
    }
}