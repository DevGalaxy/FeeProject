using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FEEWebApp.Controllers
{
    public class StudentController : BaseController<IStudentRepository, Student>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IUniteOfWork _uniteOfWork;

        public StudentController(IStudentRepository StudentRepository, IUniteOfWork uniteOfWork)
            : base(StudentRepository, uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _StudentRepository = StudentRepository;
        }

        [HttpGet("Schedules")]
        public ICollection<StaffSubjects> schedules(int studentID)
        {
            return _StudentRepository.schedules(studentID);
        }


        [HttpGet("DraftSubjects")]
        public ICollection<Subject> DraftSubjects(int studentID)
        {
            return _StudentRepository.DraftSubjects(studentID);
        }

        [HttpGet("StudentsNumber")]
        public int StudentsNumber()
        {
           return  _StudentRepository.StudentsNumber();
        }

        [HttpGet("AllSudetedSubjects")]
        public ICollection<Subject> AllSudetedSubjects(int studentID)
        {
            return _StudentRepository.AllSudetedSubjects(studentID);
        }

        [HttpGet("Degrees")]
        public ICollection<StudentSubject> Degrees(int studentID)
        {
            return _StudentRepository.Degrees(studentID);
        }

        [HttpGet("SutudingSubjects")]
        public ICollection<Subject> SutudingSubjects(int studentID)
        {
            return _StudentRepository.SutudingSubjects(studentID);
        }

        [HttpGet("EnabledSubjects")]
        public ICollection<Subject> EnabledSubjects(int studentID)
        {
            return _StudentRepository.EnabledSubjects(studentID);
        }

    }
}
