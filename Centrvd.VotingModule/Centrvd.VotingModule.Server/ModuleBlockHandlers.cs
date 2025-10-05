using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;

namespace Centrvd.VotingModule.Server.VotingModuleBlocks
{
  partial class TaskBlockHandlers
  {

    public virtual void TaskBlockStartTask(Centrvd.VotingModule.IVotingTask task)
    {
      task.Responsible = Centrvd.VotingModule.Functions.VotingTask.GetCalculatedResponsible(task, _block.Responsible);
      
      if (task.Responsible == null)
        throw AppliedCodeException.Create(Centrvd.VotingModule.VotingTasks.Resources.CannotCalculateResponsibleFormat(_block.Responsible.Name));
    }
  }

}