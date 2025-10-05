using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingTask;

namespace Centrvd.VotingModule
{
  partial class VotingTaskServerHandlers
  {

    public override void BeforeStart(Sungero.Workflow.Server.BeforeStartEventArgs e)
    {
      _obj.Voters.Clear();
      _obj.VotingResults.Clear();
      
      var employee = Centrvd.VotingModule.Functions.VotingTask.GetCalculatedResponsible(_obj, _obj.Responsible);
      _obj.Responsible = employee;
    }
  }

}