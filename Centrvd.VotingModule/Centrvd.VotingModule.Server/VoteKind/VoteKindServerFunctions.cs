using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VoteKind;

namespace Centrvd.VotingModule.Server
{
  partial class VoteKindFunctions
  {
    /// <summary>
    /// Проверить, используется ли вид голоса в матрицах голосов.
    /// </summary>
    /// <returns>True, если испольуется. Иначе - false.</returns>
    [Remote]
    public bool IsVoteKindUsedInMatrices()
    {
      return this.GetMatricesVoteKindUsed().Any();
      //      Centrvd.VotingModule.VotingPrepareAssignments.GetAll()
      //        .Any(a => a.VotingPoints.Any(v => Equals(v.VotesMatrix, _obj)));
    }
    
    /// <summary>
    /// Получить матрицы голосов, в которых используется вид голос.
    /// </summary>
    /// <returns>Список заданий.</returns>
    [Remote]
    public IQueryable<IVotesMatrix> GetMatricesVoteKindUsed()
    {
      return Centrvd.VotingModule.VotesMatrices.GetAll()
        .Where(a => a.Variants.Any(v => Equals(v.VoteKind, _obj)));
    }
  }
}