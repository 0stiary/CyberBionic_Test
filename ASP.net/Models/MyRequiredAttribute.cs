namespace ASP.net.Models
{
	public class MyRequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
	{
		public MyRequiredAttribute(string errorMessage = "Обязательное поле")
		{
			base.ErrorMessage = errorMessage;
		}
	}
}