# # Forms Generator
This NuGet package eases the way you collect information from your user. Create your own model, set some customization attributes and request a form as a ContentPage! Thanks to Dani Bautista for the idea and mentoring.

[Example Android screenshot](https://i.imgur.com/5kARyPe.jpg)

# Property types supported
String
Int
Bool
Enum
DateTime (only asks for date)

Working on adding custom classes as properties support.

# How to use it
It is insanely simple to use really.

1. Create a model
```
public class CustomModel {
    // All your properties here
}
```
2. Add a property in your ViewModel 
```
public CustomModel model { get; set; }
public TestViewModel {
    model = new CustomModel();
}
```
3. Instanciate the FormGenerator and generate the page
```
var formGenerator = new FormGenerator();
var formPage = formGenerator.GeneratePage(model);
```
4. Navigate to the page in your own way
```
await Navigation.PushAsync(formPage);
```

That's it! When you press "submit" in the formPage, the property in the ViewModel will be filled with the information provided.

# Attributes

**FormOptional** [string,int] : Entry can be empty when submitting the form

**FormIgnore** [any] : Property will not be shown on the form      
        
**FormPassword** [string] : Entry will become a password entry    
            
**FormMaxLength** [string] : Entry will have a maximum length          
             
**FormMaxValue** [int] : Entry will have a maximum number        
            
**FormIntSlider** [int] : Int will be requested as a slider

# More
I am willing to add more customization options soon. Open an issue on GitHub and I'll check it out.
