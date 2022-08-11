namespace CRM.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
