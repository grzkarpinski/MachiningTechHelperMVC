using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly Context _context;
        public GradeRepository(Context context)
        {
               _context = context;
        }
        public int AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            return grade.Id;
        }

        public void DeleteGrade(int gradeId)
        {
            var grade = _context.Grades.Find(gradeId);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return _context.Grades;
        }

        public Grade GetGradeById(int gradeId)
        {
            var grade = _context.Grades.FirstOrDefault(p => p.Id == gradeId);
            return grade;
        }

        public void UpdateGrade(Grade grade)
        {
            _context.Attach(grade);
            _context.Entry(grade).Property("GradeName").IsModified = true;
            _context.SaveChanges();
        }
    }
}
