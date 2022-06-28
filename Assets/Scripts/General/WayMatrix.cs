using UnityEngine;

public class WayMatrix
{
    private const int _width = 3;
    private const int _height = 4;
    private const float _spacing = 4;

    private Vector2[,] _matrix;

    public int Width => _width;
    public int Height => _height;
    public float Spacing => _spacing;

    public WayMatrix()
    {
        _matrix = new Vector2[Height, Width];
<<<<<<< Updated upstream
        float xPositionValue = Spacing;
=======
        DisappearPoint = new(0, 0, -50);
        Build();
    }

    private void Build()
    {
        float xPosition = VerticalSpacing;
>>>>>>> Stashed changes

        for (int x = 0; x < Height; x++)
        {
            float yPositionValue = -Spacing;

            for (int y = 0; y < Width; y++)
            {
                _matrix[x, y] = new Vector2(yPositionValue, xPositionValue);
                yPositionValue += Spacing;
            }

            xPositionValue -= Spacing;
        }
    }

    public void PrintMatrix()
    {
        string matrixOut = "\n";

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                matrixOut += "(" + _matrix[x, y].x + "," + _matrix[x, y].y + ")" + " ";
            }

            matrixOut += "\n";
        }

        Debug.Log(matrixOut);
    }

    public Vector3 GetPosition(MatrixPosition position, out Vector2Int worldMatrixCoordinates)
    {
        switch (position)
        {
            case MatrixPosition.UpLeft:
                {
                    Vector2Int matrixCoordinates = new Vector2Int(0, 0);
                    worldMatrixCoordinates = ConvertCoordinates(matrixCoordinates);
                    return _matrix[matrixCoordinates.x, matrixCoordinates.y];
                }
            case MatrixPosition.UpRight:
                {
                    Vector2Int matrixCoordinates = new Vector2Int(0, Width - 1);
                    worldMatrixCoordinates = ConvertCoordinates(matrixCoordinates);
                    return _matrix[matrixCoordinates.x, matrixCoordinates.y];
                }
            case MatrixPosition.Center:
                {
                    Vector2Int matrixCoordinates = new Vector2Int(Height - 2, Width / 2);
                    worldMatrixCoordinates = ConvertCoordinates(matrixCoordinates);
                    return _matrix[matrixCoordinates.x, matrixCoordinates.y];
                }
            case MatrixPosition.DownLeft:
                {
                    Vector2Int matrixCoordinates = new Vector2Int(Height - 1, 0);
                    worldMatrixCoordinates = ConvertCoordinates(matrixCoordinates);
                    return _matrix[matrixCoordinates.x, matrixCoordinates.y];
                }
            case MatrixPosition.DownRight:
                {
                    Vector2Int matrixCoordinates = new Vector2Int(Height - 1, Width - 1);
                    worldMatrixCoordinates = ConvertCoordinates(matrixCoordinates);
                    return _matrix[matrixCoordinates.x, matrixCoordinates.y];
                }
            default:
                {
                    goto case MatrixPosition.Center;
                }
        }
    }

    public Vector3 GetPosition(MatrixPosition position)
    {
        switch (position)
        {
            case MatrixPosition.UpLeft:
                {
                    return _matrix[0, 0];
                }
            case MatrixPosition.UpRight:
                {
                    return _matrix[0, Width - 1];
                }
            case MatrixPosition.Center:
                {
                    return _matrix[Height - 2, Width / 2];
                }
            case MatrixPosition.DownLeft:
                {
                    return _matrix[Height - 1, 0];
                }
            case MatrixPosition.DownRight:
                {
                    return _matrix[Height - 1, Width - 1];
                }
            default:
                {
                    goto case MatrixPosition.Center;
                }
        }
    }

    public Vector3 GetPositionByArrayCoordinates(Vector2Int position) => _matrix[ConvertCoordinates(position).x, ConvertCoordinates(position).y];

    public Vector3[] GetRowByIndex(int rowIndex)
    {
        Vector3[] matrixRow = new Vector3[Width];

        for (int i = 0; i < Width; i++)
        {
            matrixRow[i] = _matrix[rowIndex, i];
        }

        return matrixRow;
    }

    private Vector2Int ConvertCoordinates(Vector2Int position) => new Vector2Int(position.y, position.x);
}

public enum MatrixPosition
{
    UpLeft,
    UpRight,
    Center,
    DownLeft,
    DownRight
}
