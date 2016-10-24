using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public static class Utils
    {
        public static Task WhenClicked(this Control target, int index)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler onClick = null;
            onClick = (sender, e) =>
            {
                for (int i = 0; i < index - 1; i++)
                {
                    target.Controls[i].Click -= onClick;
                }
                tcs.TrySetResult(null);
            };
            for (int i = 0; i < index - 1; i++)
            {
                target.Controls[i].Click += onClick;
            }
            return tcs.Task;
        }
    }
}
