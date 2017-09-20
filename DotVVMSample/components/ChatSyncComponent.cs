using System.Collections.Generic;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVMSample.components
{
    public class ChatSyncComponent : HtmlGenericControl
    {
        public List<string> StringList
        {
            get => (List<string>) GetValue(StringListProp);
            set => SetValue(StringListProp, value);
        }

        public static readonly DotvvmProperty StringListProp
            = DotvvmProperty.Register<List<string>, ChatSyncComponent>(c => c.StringList, new List<string>());


        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource("chatSync");
            base.OnPreRender(context);
        }

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            var textBinding = GetValueBinding(StringListProp);
            if (textBinding != null)
            {
                writer.AddKnockoutDataBind("chatSync", this, StringListProp);
            }

            writer.AddAttribute("type", "text");

            base.AddAttributesToRender(writer, context);
        }
    }
}