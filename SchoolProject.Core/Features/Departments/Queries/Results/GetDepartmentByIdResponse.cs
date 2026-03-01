namespace SchoolProject.Core.Features.Departments.Queries.Results
{
    public class GetDepartmentByIdResponse
    {
        public int DepeartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string? ManagerName { get; set; }

        public List<StudentResponse>? StudentList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }

    }

    public class StudentResponse
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
    public class InstructorResponse
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
    }
    public class SubjectResponse
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }


}
