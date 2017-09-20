using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVMSample.components
{
    public class MyDatePicker: HtmlGenericControl
    {

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DotvvmProperty TextProperty
            = DotvvmProperty.Register<string, MyDatePicker>(c => c.Text, null);



        public MyDatePicker():base("input")
        {
            
        }
        protected override void OnPreRender(IDotvvmRequestContext context)
        {

            context.ResourceManager.AddRequiredResource("myDatePicker");
            base.OnPreRender(context);
        }

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            var textBinding = GetValueBinding(TextProperty);
            if (textBinding != null)
            {
                // the property contains binding - this will render data-bind="value: expression"
                writer.AddKnockoutDataBind("myDatePicker", this, TextProperty);
//                writer.AddKnockoutDataBind("myDatePicker", this, TextProperty);

            }
            else
            {
                // render the value in the HTML
                writer.AddAttribute("value", Text);
            }

            writer.AddAttribute("type", "text");

            base.AddAttributesToRender(writer, context);
        }
    }
}