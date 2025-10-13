using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace Centrvd.VotingModule.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      GrantAcessRights();
    }
    
    /// <summary>
    /// Выдача прав.
    /// </summary>
    public static void GrantAcessRights()
    {
      InitializationLogger.Debug("Init: Выдача прав модуля Голосование.");
      var allUsers = Roles.AllUsers;
      
      if (allUsers != null)
      {
        InitializationLogger.Debug("Init: Выдача прав на cправочники для всех пользователей.");
        Centrvd.VotingModule.VoteKinds.AccessRights.Grant(allUsers, DefaultAccessRightsTypes.Read);
        Centrvd.VotingModule.VoteKinds.AccessRights.Save();

        InitializationLogger.Debug("Init: Выдача прав на задачи для всех пользователей.");
        Centrvd.VotingModule.VotingTasks.AccessRights.Grant(allUsers, DefaultAccessRightsTypes.Create);
        Centrvd.VotingModule.VotingTasks.AccessRights.Save();
        
        InitializationLogger.Debug("Init: Выдача прав на отчет по голосованию для всех пользователей.");
        Centrvd.VotingModule.Reports.AccessRights.Grant(Reports.GetVotingResultsReport().Info, allUsers, DefaultReportAccessRightsTypes.Execute);
      }

      InitializationLogger.Debug("Init: Выдача прав на cправочники для Ответственных за настройку системы.");
      var systemSetupResponsibleRole = Roles.GetAll(x => x.Sid == Sungero.Docflow.PublicConstants.Module.RoleGuid.SystemSetupResponsibleRole).FirstOrDefault();
      if (systemSetupResponsibleRole != null)
      {
        Centrvd.VotingModule.VoteKinds.AccessRights.Grant(systemSetupResponsibleRole, DefaultAccessRightsTypes.FullAccess);
        Centrvd.VotingModule.VoteKinds.AccessRights.Save();
        
        Centrvd.VotingModule.VotesMatrices.AccessRights.Grant(systemSetupResponsibleRole, DefaultAccessRightsTypes.FullAccess);
        Centrvd.VotingModule.VotesMatrices.AccessRights.Save();
        
        Centrvd.VotingModule.VotersMatrices.AccessRights.Grant(systemSetupResponsibleRole, DefaultAccessRightsTypes.FullAccess);
        Centrvd.VotingModule.VotersMatrices.AccessRights.Save();
      }
      
    }
  }
}
