namespace Shelter.Shared
{
	class Cat: Animals
	{
		public Cat() : base()
		{

		}

		public Cat(int id, string name, dateTime dateOfBirth, bool isChecked, bool kidFriendly, dateTime since) : base(id, name, dateOfBirth, isChecked, kidFriendly, since)
		{

		}

	}
}