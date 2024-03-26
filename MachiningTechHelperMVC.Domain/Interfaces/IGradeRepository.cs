using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IGradeRepository
    {
        int AddGrade(Grade grade);
        void DeleteGrade(int gradeId);
        Grade GetGradeById(int gradeId);
        IEnumerable<Grade> GetAllGrades();
        void UpdateGrade(Grade grade);
    }
}
