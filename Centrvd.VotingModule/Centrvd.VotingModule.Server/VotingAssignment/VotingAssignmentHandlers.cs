using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingAssignment;

namespace Centrvd.VotingModule
{
  partial class VotingAssignmentVotingPointsVotePropertyFilteringServerHandler<T>
  {

    public virtual IQueryable<T> VotingPointsVoteFiltering(IQueryable<T> query, Sungero.Domain.PropertyFilteringEventArgs e)
    {
      return query;
    }
  }

}