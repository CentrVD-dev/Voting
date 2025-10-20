using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotersMatrix;

namespace Centrvd.VotingModule
{
  partial class VotersMatrixServerHandlers
  {

    public override void BeforeSave(Sungero.Domain.BeforeSaveEventArgs e)
    {
      bool hasEmployees = _obj.Employees.Any(emp => emp != null);
      bool hasRoles = _obj.Roles.Any(r => r != null);

      if (!hasEmployees && !hasRoles)
        e.AddError(Centrvd.VotingModule.VotersMatrices.Resources.EmptyEmployeeAndRole);
    }
  }

}