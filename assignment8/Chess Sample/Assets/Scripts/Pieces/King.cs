using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// King.cs
public class King : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        return new MoveInfo[]
        {
            new MoveInfo(0, 1, 1),    // ��
            new MoveInfo(0, -1, 1),   // �Ʒ�
            new MoveInfo(1, 0, 1),    // ������
            new MoveInfo(-1, 0, 1),   // ����
            new MoveInfo(1, 1, 1),    // ������ ��
            new MoveInfo(1, -1, 1),   // ������ �Ʒ�
            new MoveInfo(-1, 1, 1),   // ���� ��
            new MoveInfo(-1, -1, 1)   // ���� �Ʒ�
        };
        // ------
    }
}
