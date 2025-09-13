using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotesMatrix;

namespace Centrvd.VotingModule.Server
{
  partial class VotesMatrixFunctions
  {
    /// <summary>
    /// Проверить, используется ли матрица в заданиях подготовки голосований.
    /// </summary>
    /// <returns>True, если испольуется. Иначе - false.</returns>
    [Remote]
    public virtual bool IsMatrixUsedInAssignments()
    {
      return this.GetAssignmentsMatrixUsed().Any();
    }
    
    /// <summary>
    /// Получить список заданий подготовки голосований, в которых используется матрица голосов.
    /// </summary>
    /// <returns>Список заданий.</returns>
    [Remote]
    public virtual IQueryable<IVotingPrepareAssignment> GetAssignmentsMatrixUsed()
    {
      var assignments = Enumerable.Empty<Centrvd.VotingModule.IVotingPrepareAssignment>().AsQueryable();
      Sungero.Core.AccessRights.AllowRead(() => {
                                            assignments = Centrvd.VotingModule.VotingPrepareAssignments.GetAll()
                                              .Where(a => a.VotingPoints.Any(v => Equals(v.VotesMatrix, _obj)));
                                          });
      return assignments;
    }
  }
}