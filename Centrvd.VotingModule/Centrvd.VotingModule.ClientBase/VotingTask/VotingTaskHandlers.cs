using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingTask;

namespace Centrvd.VotingModule
{
  partial class VotingTaskClientHandlers
  {

    public virtual void ResponsibleValueInput(Centrvd.VotingModule.Client.VotingTaskResponsibleValueInputEventArgs e)
    {
      if (!Equals(e.NewValue, e.OldValue) && e.NewValue != null)
      {
        var employee = Centrvd.VotingModule.Functions.VotingTask.GetCalculatedResponsible(_obj, e.NewValue);
        
        if (employee == null)
          e.AddError(Centrvd.VotingModule.VotingTasks.Resources.CannotCalculateResponsibleFormat(e.NewValue.Name));
      }
    }

  }
}