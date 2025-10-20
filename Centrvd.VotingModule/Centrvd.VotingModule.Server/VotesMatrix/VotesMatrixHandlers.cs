using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotesMatrix;

namespace Centrvd.VotingModule
{
  partial class VotesMatrixServerHandlers
  {

    public override void BeforeSave(Sungero.Domain.BeforeSaveEventArgs e)
    {
      var minVariantsCount = Constants.VotesMatrix.MinVariantsCount;
      var variantsCount = _obj.Variants?.Count(v => v.VoteKind != null) ?? 0;
      
      if (variantsCount < minVariantsCount)
      {
        var missingCount = minVariantsCount - variantsCount;
        e.AddError(Centrvd.VotingModule.VotesMatrices.Resources.FewVoicesKindsFormat(minVariantsCount, missingCount));
      }
    }
  }


}