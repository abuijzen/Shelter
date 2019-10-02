namespace Shelter.Shared
{
	class Dog: Animals
	{
		public Dog() : base()
		{

		}

		public Dog(int id, string name, dateTime dateOfBirth, bool isChecked, bool kidFriendly, dateTime since) : base(id, name, dateOfBirth, isChecked, kidFriendly, since)
		{

		}

	}
}