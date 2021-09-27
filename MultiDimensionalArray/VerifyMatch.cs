using System;
using System.Linq;

namespace MultiDimensionalArray {

  public class VerifyMatch {

    private int[,] _array;
    private int _dimension;

    public VerifyMatch(int[,] array) {
      _array = array;
      _dimension = array.GetLength(0);
    }

    public void CheckMatch() {
      bool rowMatch = CheckRowMatch();
      bool columnMatch = CheckColumnMatch();
      bool diagonalTopLeftBottomRight = CheckDiagonalTopLeftBottomRightMatch();
      bool diagonalTopRightBottomLeft = CheckDiagonalTopRightBottomLeftMatch();
    }

    public void ShowTable() {
      int r, c;
      for (r = 0; r < _dimension; r++) {
        for (c = 0; c < _dimension; c++) {
          if (c >= 0 && c < _dimension - 1)
            Console.Write($"-{(_array[r, c])}");
          else
            Console.Write($"-{(_array[r, c])}-");
        }
        Console.Write("\n");
      }
    }

    private bool CheckRowMatch() {
      int r, c;
      int[] numbers = new int[3];

      for (r = 0; r < _dimension; r++) {
        for (c = 0; c < _dimension; c++) {
          numbers[c] = _array[r, c];
        }

        if (numbers.All(z => z == numbers[0])) {
          Console.WriteLine($"Has match in the row {r}");
          return true;
        }
      }

      return false;
    }

    private bool CheckColumnMatch() {
      int[] numbers = new int[3];
      int r, x;
      for (x = 0; x < _dimension; x++) {
        numbers = new int[3];
        for (r = 0; r < _dimension; r++) {
          numbers[r] = _array[r, x];
        }

        if (numbers.All(z => z == numbers[0])) {
          Console.WriteLine($"Has match in the column {x}");
          return true;
        }
      }

      return false;
    }

    private bool CheckDiagonalTopLeftBottomRightMatch() {
      int r;

      int[] numbers = new int[3];
      for (r = 0; r < _dimension; r++) {
        numbers[r] = _array[r, r];
      }
      
      if (numbers.All(x => x == numbers[0])) {
        Console.WriteLine("Diagonal Match is the: 'TOP LEFT -> BOTTOM RIGHT'");
        return true;
      }

      return false;
    }

    private bool CheckDiagonalTopRightBottomLeftMatch() {
      int[] numbers = new int[3];
      int r;

      for (r = 0; r < _dimension; r++) {
        numbers[r] = _array[r, _dimension - r - 1];
      }

      if (numbers.All(x => x == numbers[0])) {
        Console.WriteLine("Diagonal Match is the: 'TOP RIGHT -> BOTTOM LEFT'");
        return true;
      }
      return false;
    }
  }
}
