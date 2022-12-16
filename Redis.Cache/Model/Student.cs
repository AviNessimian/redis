namespace Redis.Cache
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ContactDetails ContactDetails { get; set; }
	}

	public class ContactDetails
	{
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}