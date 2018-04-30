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
	        //nothing
	    }
        async void GenerateFormPage(object sender, EventArgs e)
	    {
	        var formGenerator = new FormGenerator();
	        var formPage = formGenerator.GeneratePage(EmployeeModel);
	        formPage.Title = "FORM";
            //formPage.BackgroundColor = Color.DimGray;
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
