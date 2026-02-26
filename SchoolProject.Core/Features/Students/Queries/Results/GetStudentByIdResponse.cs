namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetStudentByIdResponse
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentAddress { get; set; }
        public string? DepartmentName { get; set; }
    }
}
