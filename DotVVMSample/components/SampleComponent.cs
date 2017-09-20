using System;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVMSample.components
{
    public class SampleComponent : HtmlGenericControl
    {
        public string Text
        {
            get => Convert.ToString(GetValue(TextProperty));
            set => SetValue(TextProperty, value);
        }

        public static readonly DotvvmProperty TextProperty =
            DotvvmProperty.Register<string, SampleComponent>(t => t.Text, "");


        public SampleComponent() : base("input")
        {
        }

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            writer.AddKnockoutDataBind("value", this, TextProperty, () => writer.AddAttribute("value", Text));

            writer.AddAttribute("type", "text");

            base.AddAttributesToRender(writer, context);
        }

        protected override void RenderBeginTag(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            writer.RenderSelfClosingTag(TagName);
        }

        protected override void RenderEndTag(IHtmlWriter writer, IDotvvmRequestContext context)
        {
        }

        protected override void RenderContents(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            base.RenderContents(writer, context);
        }
    }
}