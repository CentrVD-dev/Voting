using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingNotification;

namespace Centrvd.VotingModule.Server
{
  partial class VotingNotificationFunctions
  {

    /// <summary>
    /// Указано ли в настройках блока формирование результатов в карточке уведомления.
    /// </summary>
    /// <returns>True, если указано. Иначе - false.</returns>
    [Remote]
    public bool isResultinNotice()
    {
      return Centrvd.VotingModule.VotingTask.Blocks.VotingNotificationBlocks.Get(_obj.Task.Scheme, _obj.BlockUid)?.FormResultInNotice == true;
    }
  }
}