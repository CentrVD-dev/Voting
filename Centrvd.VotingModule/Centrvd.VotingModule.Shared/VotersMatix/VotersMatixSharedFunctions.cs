using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotersMatix;

namespace Centrvd.VotingModule.Shared
{
  partial class VotersMatixFunctions
  {
    /// <summary>
    /// Вычислить сотрудников из матрицы голосования.
    /// </summary>
    /// <param name="task">Задача голосования.</param>
    /// <returns>сотрудников.</returns>
    public List<Sungero.Company.IEmployee> CalculateEmployeesFromMatrix(Centrvd.VotingModule.IVotingTask votingTask)
    {
      var result = new List<Sungero.Company.IEmployee>();
      
      foreach (var employee in _obj.Employees)
      {
        // Свойство Department связано со свойством Employee для выбора разных сущностей в одном форме-списке.
        // После выбора: Если Employee заполнен, а Department пуст - выбран Employee. Если Employee и Department заполнены - выбран Department.
        if (employee.Department != null)
        {
          var employees = Sungero.Company.PublicFunctions.Module.GetEmployeesFromRecipients(new List<IRecipient>() {employee.Department}).Where(a => a != null);
          result.AddRange(employees);
        }
        else if (employee.Employee != null)
          result.Add(employee.Employee);
      }
      
      foreach (var role in _obj.Roles)
      {
        // Свойство ComputedRole связано со свойством Role для выбора разных сущностей в одном форме-списке.
        // После выбора: Если Role заполнен, а ComputedRole пуст - выбран Role. Если Role и ComputedRole заполнены - выбран ComputedRole.
        if (role.ComputedRole != null)
        {
          var computedRecipients = role.ComputedRole.Compute(votingTask).ToList();
          var computedEmployees = Sungero.Company.PublicFunctions.Module.GetEmployeesFromRecipients(computedRecipients).Where(a => a != null);
          result.AddRange(computedEmployees);
        }
        else if (role.Role != null)
        {
          var computedEmployees = Sungero.Company.PublicFunctions.Module.GetEmployeesFromRecipients(new List<IRecipient>() {role.Role}).Where(a => a != null);
          result.AddRange(computedEmployees);
        }
      }
      
      return result.Distinct().ToList();
    }
  }
}