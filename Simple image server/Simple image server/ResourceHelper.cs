using System.Text;
using System.Windows.Forms;

namespace Simple_image_server
{
    public static class ResourceHelper
    {
        public static StringBuilder MissingResourceentries = new StringBuilder();

        public static void ApplyResources(Control parent, bool first = true)
        {
            if (first)
            {
                string resourceValue = Properties.Resources.ResourceManager.GetString(parent.Name);
                if (!string.IsNullOrEmpty(resourceValue))
                {
                    parent.Text = resourceValue;
                }
            }

            foreach (Control control in parent.Controls)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    continue;
                }
                if(control.GetType().Name == "NumericUpDown" || control.GetType().Name == "TextBox" || control.GetType().Name == "ComboBox")
                {
                    continue;
                }

                try
                {
                    string resourceValue = Properties.Resources.ResourceManager.GetString(control.Name);
                    if(resourceValue == null)
                    {
                        MissingResourceentries.AppendLine(control.Name +"-"+control.Text);
                    }
                    if (!string.IsNullOrEmpty(resourceValue))
                    {
                        control.Text = resourceValue;
                    }
                }
                catch
                {
                    // Intet fundet? Vær stille som graven
                }

                if (control.HasChildren)
                {
                    ApplyResources(control, first: false);
                }
            }
        }
    }
}
