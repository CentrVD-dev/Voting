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
    public virtual void Report(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      var report = Centrvd.VotingModule.Reports.GetVotingResultsReport();
      report.Entity = _obj;
      report.TaskId = _obj.Id;
      report.Open();
    }

    public virtual bool CanReport(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return true;
    }

  }

}