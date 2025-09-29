using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingTask;

namespace Centrvd.VotingModule.Client
{
  partial class VotingTaskActions
  {
    public virtual void CurrentResultsReport(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      var report = Centrvd.VotingModule.Reports.GetVotingResultsReport();
      report.Entity = _obj;
      report.Open();
    }

    public virtual bool CanCurrentResultsReport(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return Equals(Users.Current, _obj.Author) && !_obj.State.IsInserted;
    }

  }

}