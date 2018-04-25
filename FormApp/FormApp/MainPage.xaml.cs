using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsGenerator;
using Xamarin.Forms;

namespace FormApp
{
	public partial class MainPage : ContentPage
	{
	    public Employee EmployeeModel { get; set; }
		public MainPage()
		{
			InitializeComponent();
		    EmployeeModel = new Employee();
        }

	    async void GenerateFormPage(object sender, EventArgs e)
	    {
	        var formGenerator = new FormGenerator();
	        var formPage = formGenerator.GeneratePage<Employee>(EmployeeModel);
	        await Navigation.PushAsync(formPage);
	    }
	}
}
