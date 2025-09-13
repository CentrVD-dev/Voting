using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingTask;

namespace Centrvd.VotingModule.Server
{
  partial class VotingTaskFunctions
  {
    /// <summary>
    /// Получение последнего задания подготовку голосования.
    /// </summary>
    /// <returns>Последнее задание на подготовку голосования.</returns>
    public virtual Centrvd.VotingModule.IVotingPrepareAssignment GetLastPrepareAssignment()
    {
      return Centrvd.VotingModule.VotingPrepareAssignments
        .GetAll(a => Equals(a.Task, _obj) && a.Created > _obj.Started)
        .OrderByDescending(asg => asg.Created)
        .FirstOrDefault();
    }
  }
}