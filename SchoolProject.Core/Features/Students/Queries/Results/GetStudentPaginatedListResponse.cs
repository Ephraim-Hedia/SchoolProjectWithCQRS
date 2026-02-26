namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentAddress { get; set; }
        public string? DepartmentName { get; set; }
        public GetStudentPaginatedListResponse(int studentId, string? studentName, string? studentAddress, string? departmentName)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentAddress = studentAddress;
            DepartmentName = departmentName;
        }
    }
}
