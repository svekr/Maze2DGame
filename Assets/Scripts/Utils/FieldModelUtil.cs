using com.MazeGame.Model;
using UnityEngine;

namespace Utils
{
  static public class FieldModelUtil
  {
    static public CellModel GetNeighbourCell(CellModel cellModel, Direction direction, CellModel[,] fieldModel)
    {
      switch (direction)
      {
        case Direction.Up:
          if (cellModel.Index.y + 1 < fieldModel.GetLength(1))
          {
            return fieldModel[cellModel.Index.x, cellModel.Index.y + 1];
          }
          return null;
        case Direction.Right:
          if (cellModel.Index.x + 1 < fieldModel.GetLength(0))
          {
            return fieldModel[cellModel.Index.x + 1, cellModel.Index.y];
          }
          return null;
        case Direction.Down:
          if (cellModel.Index.y > 0)
          {
            return fieldModel[cellModel.Index.x, cellModel.Index.y - 1];
          }
          return null;
        case Direction.Left:
          if (cellModel.Index.x > 0)
          {
            return fieldModel[cellModel.Index.x - 1, cellModel.Index.y];
          }
          return null;
        default:
          return null;
      }
    }

    static public Direction InverseDirection(Direction direction)
    {
      switch (direction)
      {
        case Direction.Up:
          return Direction.Down;
        case Direction.Right:
          return Direction.Left;
        case Direction.Down:
          return Direction.Up;
        case Direction.Left:
          return Direction.Right;
        default:
          return direction;
      }
    }

    static public Vector2Int GetMovement(Direction direction, int distance = 1)
    {
      int x = 0;
      int y = 0;
      if (direction.HasFlag(Direction.Up)) y += distance;
      if (direction.HasFlag(Direction.Right)) x += distance;
      if (direction.HasFlag(Direction.Down)) y -= distance;
      if (direction.HasFlag(Direction.Left)) x -= distance;
      return new Vector2Int(x, y);
    }

    static public Direction GetDirectionByPosition(Vector2Int oldPosition, Vector2Int newPosition)
    {
      Direction result = Direction.None;
      if (newPosition.y > oldPosition.y) result |= Direction.Up;
      if (newPosition.x > oldPosition.x) result |= Direction.Right;
      if (newPosition.y < oldPosition.y) result |= Direction.Down;
      if (newPosition.x < oldPosition.x) result |= Direction.Left;
      return result;
    }
  }
}