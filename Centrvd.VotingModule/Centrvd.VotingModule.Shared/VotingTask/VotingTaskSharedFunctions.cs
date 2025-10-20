using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingTask;

namespace Centrvd.VotingModule.Shared
{
  partial class VotingTaskFunctions
  {

    /// <summary>
    /// Вычислить ответственного за подготовку голосования.
    /// </summary>
    /// <param name="recipient">Субъект прав (роль, группа).</param>
    /// <returns>Сотрудник.</returns>
    public Sungero.Company.IEmployee GetCalculatedResponsible(Sungero.CoreEntities.IRecipient recipient)
    {
      var employee = Sungero.Company.Employees.Null;
      
      if (recipient != null)
        employee = Sungero.Company.PublicFunctions.Module.GetEmployeesFromRecipients(new List<Sungero.CoreEntities.IRecipient>() {recipient})
          .Where(a => a != null).FirstOrDefault();
      
     return employee;
    }
  }
}