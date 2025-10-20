using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingNotification;

namespace Centrvd.VotingModule
{
  partial class VotingNotificationClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      Functions.VotingNotification.SetVisibleProperties(_obj);
    }

  }
}