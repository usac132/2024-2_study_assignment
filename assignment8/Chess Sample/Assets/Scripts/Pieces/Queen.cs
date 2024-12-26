using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        // Rook ����
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(0, 1, i));    // ��
            moves.Add(new MoveInfo(0, -1, i));   // �Ʒ�
            moves.Add(new MoveInfo(1, 0, i));    // ������
            moves.Add(new MoveInfo(-1, 0, i));   // ����
        }

        // Bishop ����
        for (int i = 1; i < Utils.FieldWidth; i++)
        {
            moves.Add(new MoveInfo(1, 1, i));    // ������ ��
            moves.Add(new MoveInfo(1, -1, i));   // ������ �Ʒ�
            moves.Add(new MoveInfo(-1, 1, i));   // ���� ��
            moves.Add(new MoveInfo(-1, -1, i));  // ���� �Ʒ�
        }

        return moves.ToArray();
        // ------
    }
}