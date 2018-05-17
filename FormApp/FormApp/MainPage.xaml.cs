using System;
using FormsGenerator;
using Xamarin.Forms;

namespace FormApp
{
	public partial class MainPage : ContentPage
    {
	    public Employee EmployeeModel { get; set; }
        public ModelTest ModelTest { get; set; }
        public Payment Payment { get; set; }
        public MainPage()
		{
			InitializeComponent();
		    EmployeeModel = new Employee();
		    ModelTest = new ModelTest();
            Payment = new Payment();
        }
	    public void CheckEmployee(object sender, EventArgs e)
	    {
            Console.WriteLine(EmployeeModel);
	        // INTERRUPTION PONIT TO CHECK EMPLOYEE HERE
	    }
        async void GenerateFormPage(object sender, EventArgs e)
	    {
	        var formGenerator = new FormGenerator();
            var formPage = formGenerator.GeneratePage(EmployeeModel, FormsGenerator.Strategy.GridType.Default, "Submit Form");
	        formPage.Title = "Employee Form";
	        await Navigation.PushAsync(formPage);
	    }
	    async void GenerateFormPageTest(object sender, EventArgs e)
	    {
            var formGenerator = new FormGenerator();
            var formPage = formGenerator.GeneratePage(EmployeeModel, FormsGenerator.Strategy.GridType.Popup, "Popup mann");
            formPage.Title = "Employee Form";
            await Navigation.PushAsync(formPage);
        }
    }
}
