using System;
using Sungero.Core;

namespace Centrvd.VotingModule.Constants
{
  public static class VotesMatrix
  {

    /// <summary>
    /// Константа для хранения минимального количества голосов в матрице.
    /// </summary>
    public const int MinVariantsCount = 2;
    
    /// <summary>
    /// Параметр для хранения признака использования матрицы в заданиях.
    /// </summary>
    public const string UsedInAssignments = "UsedInAssignments";
  }
}