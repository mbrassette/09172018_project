using System;

namespace Archon.Interview
{
	public class Property
	{
		public string AccountNumber { get; private set; }
		public string Address1 { get; private set; }
		public string Address2 { get; private set; }

		/// <summary>
		/// True when the property is an apartment or suite
		/// </summary>
		public bool IsApartment
		{
			get { return true; }
		}

		/// <summary>
		/// Gets the municipal district that the property is located in
		/// </summary>
		public char District
		{
			get { return '\0'; }
		}

		public Property(string accountNumber, string address1, string address2)
		{
			if (string.IsNullOrEmpty(accountNumber))
				throw new ArgumentNullException("accountNumber", "Account number is required");

			this.AccountNumber = accountNumber;
			this.Address1 = address1;
			this.Address2 = address2;
		}

		/// <summary>
		/// Returns true when the property is located on the street name specified, otherwise false
		/// </summary>
		public bool IsOnStreet(string streetName)
		{
			// TODO: Implement method
			throw new NotImplementedException();
		}
	}
}
