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
    public virtual bool IsVoteKindUsedInMatrices()
    {
      return this.GetMatricesVoteKindUsed().Any();
    }
    
    /// <summary>
    /// Получить матрицы голосов, в которых используется вид голос.
    /// </summary>
    /// <returns>Список заданий.</returns>
    [Remote]
    public virtual IQueryable<IVotesMatrix> GetMatricesVoteKindUsed()
    {
      var matrices = Enumerable.Empty<Centrvd.VotingModule.IVotesMatrix>().AsQueryable();
      Sungero.Core.AccessRights.AllowRead(() =>
                                          {
                                            matrices = Centrvd.VotingModule.VotesMatrices.GetAll()
                                              .Where(a => a.Variants.Any(v => Equals(v.VoteKind, _obj)));
                                          });
      return matrices;
    }
  }
}