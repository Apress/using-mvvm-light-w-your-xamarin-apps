using System;
namespace FootballCards_02.Droid
{
	public static class App
	{
		private static ViewModelLocator locator;

		public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());
	}
}

