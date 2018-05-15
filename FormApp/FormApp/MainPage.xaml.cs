using System;
using FormsGenerator;
using Xamarin.Forms;

namespace FormApp
{
	public partial class MainPage : ContentPage
	{
	    public Employee EmployeeModel { get; set; }
        public ModelTest ModelTest { get; set; }
        public MainPage()
		{
			InitializeComponent();
		    EmployeeModel = new Employee();
		    ModelTest = new ModelTest();
        }
	    public void CheckEmployee(object sender, EventArgs e)
	    {
            Console.WriteLine(EmployeeModel);
	        // INTERRUPTION PONIT TO CHECK EMPLOYEE HERE
	    }
        async void GenerateFormPage(object sender, EventArgs e)
	    {
	        var formGenerator = new FormGenerator();
            var formPage = formGenerator.GeneratePage(EmployeeModel, "Submit Form");
	        formPage.Title = "Employee Form";
	        await Navigation.PushAsync(formPage);
	    }
	    async void GenerateFormPageTest(object sender, EventArgs e)
	    {
	        var formGenerator = new FormGenerator();
	        var formPage = formGenerator.GeneratePage(ModelTest);
	        formPage.Title = "FORM TEST";
	        await Navigation.PushAsync(formPage);
	    }
    }
}
