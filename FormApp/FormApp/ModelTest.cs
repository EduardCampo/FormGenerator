using System;
using System.Collections.Generic;
using System.Text;
using FormsGenerator;

namespace FormApp
{
    public class ModelTest
    {
        // [FormMaxLength(n)]
        // [FormMaxValue(n)]
        // [FormPassword]
        // [FormOptional]
        // [FormIgnore]
        // [FormSlider(n,n)]

        [FormIntSlider(0, 10,7)]
        public int Slider { get; set; }
        [FormIntSlider(0, 10)]
        public int Slider0 { get; set; }


    }
}
